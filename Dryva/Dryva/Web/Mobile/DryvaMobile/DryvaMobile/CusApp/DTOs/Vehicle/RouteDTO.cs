using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.DTOs.Vehicle
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
