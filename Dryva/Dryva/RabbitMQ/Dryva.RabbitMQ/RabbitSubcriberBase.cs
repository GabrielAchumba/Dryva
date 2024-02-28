using System;
using System.Collections.Generic;
using System.Text;

namespace Dryva.RabbitMQ
{
    public class RabbitSubcriberBase
    {
        protected IRabbitManager RabbitManager { get; }
        public RabbitSubcriberBase(IRabbitManager manager)
        {
            this.RabbitManager = manager;
        }
    }
}
