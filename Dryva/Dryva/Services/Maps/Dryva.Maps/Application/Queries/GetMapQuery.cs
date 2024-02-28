using Dryva.Maps.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Maps.Application.Queries
{
    public class GetMapQuery : IRequest<IEnumerable<MapAxisDTO>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetMapQuery(int pageIndex = 1, int pageSize = 100)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
    }
}
