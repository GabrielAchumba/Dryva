using Dryva.Devices.Constants;
using Dryva.Devices.DTOs;
using Dryva.Devices.Repositories.Commands;
using Dryva.Devices.Repositories.Queries;
using Dryva.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Devices.RabbitSubscribers
{
    public class RouteRabbitScriber : RabbitSubcriberBase
    {
        public RouteRabbitScriber(IRabbitManager manager, IRabbitUpdateCommand commandRepo) : base(manager)
        {
            manager.Subscribe<RouteDTO>(RouteConstant.Device_Route_Queue, RouteConstant.Device_Route_Update, (dtoModel) =>
            {
                Task.Run(() => commandRepo.UpdateDeviceRoute(dtoModel));
            });

        }
    }
}
