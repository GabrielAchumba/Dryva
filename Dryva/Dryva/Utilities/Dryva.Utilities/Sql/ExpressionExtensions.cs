using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dryva.Utitlties.Sql
{
    public static class ExpressionExtensions
    {
        public static Expression Visit<TExpression>(this Expression expression,
            Func<TExpression, Expression> visitor)
            where TExpression : Expression
        {
            return ExpressionVisitor<TExpression>.Visit(expression, visitor);
        }

        public static TReturn Visit<TExpression, TReturn>(this TReturn expression,
            Func<TExpression, Expression> visitor)
            where TExpression : Expression
            where TReturn : Expression
        {
            return (TReturn)ExpressionVisitor<TExpression>.Visit(expression, visitor);
        }

        public static Expression<TDelegate> Visit<TExpression, TDelegate>(
            this Expression<TDelegate> expression, Func<TExpression, Expression> visitor)
            where TExpression : Expression
        {
            return ExpressionVisitor<TExpression>.Visit(expression, visitor);
        }

        public static void VisitWhere<TExpression>(this Expression expression,
            Action<TExpression, string, int> visitor)
            where TExpression : Expression
        {
            WhereExpressionVisitor<TExpression>.Visit(expression, visitor);
        }

        public static string GetMemberName(this LambdaExpression memberSelector)
        {
            Func<Expression, string> nameSelector = null;  //recursive func
            nameSelector = e => //or move the entire thing to a separate recursive method
            {
                switch (e.NodeType)
                {
                    case ExpressionType.Parameter:
                        return ((ParameterExpression)e).Name;
                    case ExpressionType.MemberAccess:
                        return ((MemberExpression)e).Member.Name;
                    case ExpressionType.Call:
                        return ((MethodCallExpression)e).Method.Name;
                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                        return nameSelector(((UnaryExpression)e).Operand);
                    case ExpressionType.Invoke:
                        return nameSelector(((InvocationExpression)e).Expression);
                    case ExpressionType.ArrayLength:
                        return "Length";
                    default:
                        throw new Exception("not a proper member selector");
                }
            };

            return nameSelector(memberSelector.Body);
        }
    }

    public class ExpressionVisitor<TExpression> : ExpressionVisitor where TExpression : Expression
    {
        private readonly Func<TExpression, Expression> _visitor;

        public ExpressionVisitor(Func<TExpression, Expression> visitor)
        {
            _visitor = visitor;
        }

        public override Expression Visit(Expression expression)
        {
            if (expression is TExpression && _visitor != null)
                expression = _visitor(expression as TExpression);

            return base.Visit(expression);
        }

        public static Expression Visit(Expression expression, Func<TExpression, Expression> visitor)
        {
            return new ExpressionVisitor<TExpression>(visitor).Visit(expression);
        }

        public static Expression<TDelegate> Visit<TDelegate>(Expression<TDelegate> expression,
            Func<TExpression, Expression> visitor)
        {
            return (Expression<TDelegate>)new ExpressionVisitor<TExpression>(visitor).Visit(expression);
        }

    }
    public class WhereExpressionVisitor<TExpression>:ExpressionVisitor where TExpression : Expression
    {
        private readonly Action<TExpression, string, int> visitor;
        private readonly StringBuilder builder;
        private readonly Stack<string> operators;
        private readonly Type stringType;

        public WhereExpressionVisitor(Action<TExpression, string, int> visitor)
        {
            this.visitor = visitor;
            builder = new StringBuilder();
            operators = new Stack<string>();
            stringType = typeof(string);
        }

        public override Expression Visit(Expression expression)
        {
            if (expression == null)
                return base.Visit(expression);

            switch (expression.NodeType)
            {
                case ExpressionType.AndAlso:
                    operators.Push(" AND ");
                    break;

                case ExpressionType.OrElse:
                    operators.Push(" OR ");
                    break;

                case ExpressionType.LessThan:
                    operators.Push(" < ");
                    break;

                case ExpressionType.LessThanOrEqual:
                    operators.Push(" <= ");
                    break;

                case ExpressionType.GreaterThan:
                    operators.Push(" > ");
                    break;

                case ExpressionType.GreaterThanOrEqual:
                    operators.Push(" >= ");
                    break;

                case ExpressionType.Equal:
                    operators.Push(" = ");
                    break;

                case ExpressionType.NotEqual:
                    operators.Push(" != ");
                    break;

                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                    operators.Push(" + ");
                    break;

                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    operators.Push(" - ");
                    break;

                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                    operators.Push(" * ");
                    break;

                case ExpressionType.Divide:
                    operators.Push(" / ");
                    break;

                case ExpressionType.Constant:
                    var constantExpression = expression as ConstantExpression;

                    if (constantExpression.Type == stringType)
                    {
                        var value = $"'{constantExpression.Value}'";
                        OnVisit(Expression.Constant(value, stringType), null, 2);
                    }
                    else
                        OnVisit(expression, null, 2);

                    if (operators.Count > 0)
                        OnVisit(Expression.Constant(operators.Pop(), stringType), null, 1);
                    break;

                case ExpressionType.MemberAccess:
                case ExpressionType.Parameter:
                case ExpressionType.Call:
                    break;

                default:
                    throw new InvalidOperationException("The syntax is not valid in a WHERE clause.");
            }
            return base.Visit(expression);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            switch (node.Expression.NodeType)
            {
                case ExpressionType.Constant:
                case ExpressionType.MemberAccess:
                    {
                        var cleanNode = GetMemberConstant(node);
                        return Visit(cleanNode);
                    }
                default:
                    {
                        var name = $"[{node.Member.Name}]";
                        OnVisit(Expression.Constant(name, stringType), node.Member.Name, 0);

                        if (operators.Count > 0)
                            OnVisit(Expression.Constant(operators.Pop(), stringType), null, 1);

                        return base.VisitMember(node);
                    }
            }
        }

        private Expression OnVisit(Expression expression, string parameter, int valueType)
        {
            if (expression is TExpression && visitor != null)
                visitor(expression as TExpression, parameter, valueType);

            return expression;
        }

        private static ConstantExpression GetMemberConstant(MemberExpression node)
        {
            object value;

            if (node.Member.MemberType == MemberTypes.Field)
            {
                value = GetFieldValue(node);
            }
            else if (node.Member.MemberType == MemberTypes.Property)
            {
                value = GetPropertyValue(node);
            }
            else
            {
                throw new NotSupportedException();
            }

            return Expression.Constant(value, node.Type);
        }

        private static object GetFieldValue(MemberExpression node)
        {
            var fieldInfo = (FieldInfo)node.Member;
            var instance = (node.Expression == null) ? null : TryEvaluate(node.Expression).Value;

            return fieldInfo.GetValue(instance);
        }

        private static object GetPropertyValue(MemberExpression node)
        {
            var propertyInfo = (PropertyInfo)node.Member;
            var instance = (node.Expression == null) ? null : TryEvaluate(node.Expression).Value;

            return propertyInfo.GetValue(instance, null);
        }

        private static bool IsClosure(object value)
        {
            if (value != null && Attribute.IsDefined(value.GetType(), typeof(CompilerGeneratedAttribute)))
                return true;
            return false;
        }

        private static ConstantExpression TryEvaluate(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Constant)
            {
                return (ConstantExpression)expression;
            }
            throw new NotSupportedException();
        }

        public static Expression Visit(Expression expression, Action<TExpression, string, int> visitor)
        {
            return new WhereExpressionVisitor<TExpression>(visitor).Visit(expression);
        }

        public static Expression<TDelegate> Visit<TDelegate>(Expression<TDelegate> expression,
            Action<TExpression, string, int> visitor)
        {
            return (Expression<TDelegate>)new WhereExpressionVisitor<TExpression>(visitor).Visit(expression);
        }

    }
}
