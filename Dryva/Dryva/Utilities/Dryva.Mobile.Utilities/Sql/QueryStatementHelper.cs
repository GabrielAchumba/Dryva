using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dryva.Utitlties.Sql
{
    public interface IQueryBuilder<TModel> where TModel : class
    {
        string Query { get; }
    }

    /// <summary>
    /// Represents the query statement helper class.
    /// </summary>
    public static class QueryStatementHelper
    {
        /// <summary>
        /// Generates the Transact SQL SELECT statement.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>ColumnsBuilder&lt;TModel&gt;.</returns>
        public static ColumnsBuilder<TModel> Select<TModel>(Expression<Func<TModel, object>> expression,
            string tableName) where TModel : class
        {
            return new ColumnsBuilder<TModel>(expression, tableName);
        }

        /// <summary>
        /// Generates the Transact SQL DELETE statement.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DeleteBuilder&lt;TModel&gt;.</returns>
        public static DeleteBuilder<TModel> Delete<TModel>(string tableName) where TModel : class
        {
            return new DeleteBuilder<TModel>(tableName);
        }

        /// <summary>
        /// Generates the Transact SQL WHERE clause.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="builder">The query builder.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>WhereBuilder&lt;TModel&gt;.</returns>
        public static WhereBuilder<TModel> Where<TModel>(this IQueryBuilder<TModel> builder,
            Expression<Func<TModel, bool>> expression) where TModel : class
        {
            return new WhereBuilder<TModel>(builder, expression);
        }
    }

    /// <summary>
    /// Represents the columns builder class.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class ColumnsBuilder<TModel> : IQueryBuilder<TModel> where TModel : class
    {
        private readonly List<string> columns;
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnsBuilder{TModel}"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="tableName">Name of the table.</param>
        public ColumnsBuilder(Expression<Func<TModel, object>> expression, string tableName)
        {
            columns = new List<string>();
            Query = GetSqlQuery(expression, tableName);
        }

        /// <summary>
        /// Gets the SELECT query.
        /// </summary>
        /// <value>The query.</value>
        public string Query { get; }
        /// <summary>
        /// Gets the columns in the query.
        /// </summary>
        /// <value>The columns in the query.</value>
        public IReadOnlyList<string> Columns => columns;

        /// <summary>
        /// Gets the SQL query.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentException">The expression must only be of type NewExpression. - expression</exception>
        private string GetSqlQuery(Expression<Func<TModel, object>> expression, string tableName)
        {
            var newExpression = expression.Body as NewExpression ??
                throw new ArgumentException("The expression must only be of type NewExpression.",
                nameof(expression));

            bool wroteSelect = false;
            var builder = new StringBuilder();
            builder.Append("SELECT ");

            foreach (var memberInfo in newExpression.Members)
            {
                if (wroteSelect)
                    builder.Append(", ");

                builder.AppendFormat("[{0}]", memberInfo.Name);
                columns.Add(memberInfo.Name);
                wroteSelect = true;
            }

            builder.AppendFormat(" FROM {0}", tableName);
            builder.AppendLine();

            return builder.ToString();
        }
    }
    public class DeleteBuilder<TModel> : IQueryBuilder<TModel> where TModel : class
    {
        public DeleteBuilder(string tableName)
        {
            Query = GetSqlQuery(tableName);
        }

        private string GetSqlQuery(string tableName)
        {
            return $"DELETE FROM {tableName}\r\n";
        }

        public string Query { get; }
    }
    /// <summary>
    /// Represents the constraint builder class.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    [Obsolete]
    public class ConstraintBuilder<TModel> where TModel : class
    {
        private readonly ColumnsBuilder<TModel> columnsBuilder;
        public ConstraintBuilder(ColumnsBuilder<TModel> columnsBuilder)
        {
            this.columnsBuilder = columnsBuilder;
            Query = columnsBuilder.Query;
            Parameters = null;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintBuilder{TModel}" /> class.
        /// </summary>
        /// <param name="columnsBuilder">The columns builder.</param>
        /// <param name="constraintExpression">The constraint expression.</param>
        /// <exception cref="ArgumentException">The expression must be of type MemberInitExpression. - constraintExpression</exception>
        /// <exception cref="ArgumentException">The expression MemberBinding must only be type MemberAssignment. - constraintExpression</exception>
        /// <exception cref="ArgumentException">The MemberAssignment expression is not a ConstantExpression. - constraintExpression</exception>
        public ConstraintBuilder(ColumnsBuilder<TModel> columnsBuilder, Expression<Func<TModel, TModel>> constraintExpression)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            var memberInitExpression =
                constraintExpression.Body as MemberInitExpression ??
                throw new ArgumentException("The expression must be of type MemberInitExpression.",
                nameof(constraintExpression));

            var query = columnsBuilder.Query;
            var builder = new StringBuilder(query.Length * 2);
            bool wroteWhere = false;

            builder.Append("WHERE ");

            foreach (var binding in memberInitExpression.Bindings)
            {
                if (wroteWhere)
                    builder.Append(" AND ");

                var propertyName = binding.Member.Name;

                var memberAssignment = binding as MemberAssignment ??
                    throw new ArgumentException("The expression MemberBinding must only be type MemberAssignment.",
                    nameof(constraintExpression));

                Expression memberExpression = memberAssignment.Expression;
                ParameterExpression parameterExpression = null;

                memberExpression.Visit((ParameterExpression p) =>
                {
                    parameterExpression = p;
                    return p;
                });

                object value;

                if (memberExpression.NodeType == ExpressionType.Constant)
                {
                    var constantExpression = memberExpression as ConstantExpression ??
                        throw new ArgumentException("The MemberAssignment expression is not a ConstantExpression.",
                        nameof(constraintExpression));

                    value = constantExpression.Value;
                }
                else
                {
                    LambdaExpression lambda = Expression.Lambda(memberExpression, null);
                    value = lambda.Compile().DynamicInvoke();
                }

                if (value != null)
                {
                    builder.AppendFormat("[{0}] = @{0}", propertyName);
                }
                else
                {
                    builder.AppendFormat("[{0}] = NULL", propertyName);
                }
                properties.Add(propertyName, value);
                wroteWhere = true;
            }

            Query = query + builder.ToString();
            Parameters = properties.Aggregate(new ExpandoObject() as IDictionary<string, object>,
                (a, p) =>
                {
                    a.Add(p.Key, p.Value);
                    return a;
                });
        }
        public ConstraintBuilder<TModel> Constraint(Expression<Func<TModel, TModel>> constraintExpression)
        {
            return new ConstraintBuilder<TModel>(columnsBuilder, constraintExpression);
        }

        /// <summary>
        /// Gets the SELECT query.
        /// </summary>
        /// <value>The query.</value>
        public string Query { get; }
        /// <summary>
        /// Gets the parameters of the query.
        /// </summary>
        /// <value>The parameters.</value>
        public dynamic Parameters { get; }
    }

    public class WhereBuilder<TModel> : IQueryBuilder<TModel> where TModel : class
    {
        public WhereBuilder(IQueryBuilder<TModel> queryBuilder, Expression<Func<TModel, bool>> expression)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            var binaryExpression =
                expression.Body as BinaryExpression ??
                throw new ArgumentException("The expression must be of type BinaryExpression.",
                nameof(expression));

            var query = queryBuilder.Query;
            var builder = new StringBuilder(query.Length * 2);
            //if (query.Contains("WHERE", StringComparison.OrdinalIgnoreCase))
            if (query.ToUpper().Contains("WHERE"))
                builder.Append(" AND ");
            else
                builder.Append("WHERE ");

            binaryExpression.VisitWhere((ConstantExpression c, string s, int v) =>
            {
                var value = c.Value;
                if (v == 0)
                {
                    properties.Add(s, null);
                }
                else if (v == 2)
                {
                    var key = properties.Last().Key;
                    value = value?.ToString().Trim('\'');

                    properties[key] = value;
                    value = $"@{key}";
                }
                builder.Append(value);
            });

            Query = queryBuilder.Query + builder.ToString();
            Parameters = properties.Aggregate(new ExpandoObject() as IDictionary<string, object>,
                (a, p) =>
                {
                    a.Add(p.Key, p.Value);
                    return a;
                });
        }
        /// <summary>
        /// Gets the SELECT query.
        /// </summary>
        /// <value>The query.</value>
        public string Query { get; }
        /// <summary>
        /// Gets the parameters of the query.
        /// </summary>
        /// <value>The parameters.</value>
        public dynamic Parameters { get; }
    }
}
