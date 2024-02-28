using System;
using System.Collections.Generic;
using System.Text;

namespace Dryva.Utilities.Paging
{
    /// <summary>
    /// Represents a paged-list extensions class.
    /// </summary>
    public static class PagedListExtensions
    {
        /// <summary>
        /// Converts the IEnumerable&lt;TModel&gt; source to a paged-list using the default page size and number.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>PagedList&lt;TModel&gt;.</returns>
        public static PagedList<TModel> ToPagedList<TModel>(this IEnumerable<TModel> source)
        {
            return source.ToPagedList(1, 20);
        }

        /// <summary>
        /// Converts the IEnumerable&lt;TModel&gt; source to a paged-list using the specified page size and number.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <returns>PagedList&lt;TModel&gt;.</returns>
        public static PagedList<TModel> ToPagedList<TModel>(this IEnumerable<TModel> source, int pageNumber, int pageSize)
        {
            return PagedList<TModel>.ToPagedList(source, pageNumber, pageSize);
        }
    }
}
