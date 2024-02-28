using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Web.Hubs
{
    public interface ICaptureSessionService
    {
        IHubContext<CaptureSessionHub> Context { get; }
    }

    public class CaptureSessionService : ICaptureSessionService
    {
        public CaptureSessionService(IHubContext<CaptureSessionHub> context)
        {
            Context = context;
        }

        public IHubContext<CaptureSessionHub> Context { get; }
    }
}

