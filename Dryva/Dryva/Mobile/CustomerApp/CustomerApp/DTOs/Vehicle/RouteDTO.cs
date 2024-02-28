using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.DTOs.Vehicle
{
    public class RouteDTO: BaseDTO
    {
        public string RouteName { get; set; }

        public override string ToString()
        {
            return RouteName;
        }
    }
}
