using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dryva.Utilities.Paging
{
    /// <summary>
    /// Represents a paging parameters class.
    /// </summary>
    public abstract class PagingParameters
    {
        const int maxPageSize = 50;
        private int pageSize = 20;

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > maxPageSize ? maxPageSize : value; }
        }

        /// <summary>
        /// Gets the response header X-Pagination content.
        /// </summary>
        /// <value>The header.</value>
        public virtual string Header { get { return JsonConvert.SerializeObject(MetaData); } }
        /// <summary>
        /// Gets the paging meta data.
        /// </summary>
        /// <value>The meta data.</value>
        protected abstract dynamic MetaData { get; }
    }
}
