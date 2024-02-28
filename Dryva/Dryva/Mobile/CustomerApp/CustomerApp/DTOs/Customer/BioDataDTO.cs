using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.DTOs.Customer
{
    public class BioDataDTO : BaseDTO
    {
        /// <summary>
        /// Gets or sets the photograph.
        /// </summary>
        /// <value>The photograph.</value>
        public byte[] Photograph { get; set; }
    }
}
