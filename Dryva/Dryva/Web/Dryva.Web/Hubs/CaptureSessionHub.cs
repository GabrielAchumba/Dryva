using Dryva.Web.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebkitFrameworkCore.Helpers;

namespace Dryva.Web.Hubs
{
    public class CaptureSessionHub : Hub
    {
        private static readonly ConcurrentDictionary<string, UserHubModel> Users =
            new ConcurrentDictionary<string, UserHubModel>(StringComparer.InvariantCultureIgnoreCase);

        //private readonly ApplicationDbContext db;

        //public CaptureSessionHub(ApplicationDbContext db)
        //{
        //    this.db = db;
        //}

        public override Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var user = Users.GetOrAdd(userName, _ => new UserHubModel
            {
                UserName = userName,
                ConnectionIds = new HashSet<string>()
            });

            lock (user.ConnectionIds)
            {
                user.ConnectionIds.Add(connectionId);
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            UserHubModel user;
            Users.TryGetValue(userName, out user);

            if (user != null)
            {
                lock (user.ConnectionIds)
                {
                    user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
                    if (!user.ConnectionIds.Any())
                    {
                        UserHubModel removedUser;
                        Users.TryRemove(userName, out removedUser);
                    }
                }
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task<CaptureSessionDTO> GetCaptureSession(Guid session)
        {
            throw new NotImplementedException();
            //var captureSession = await db.CaptureSessions.SingleOrDefaultAsync(cs => cs.Id == session);
            //return captureSession;
        }

        public async Task NotifyNewCapture(IHubContext<CaptureSessionHub> hubContext, Guid session)
        {
            var captureSession = await GetCaptureSession(session);
            var userName = captureSession.CreatedBy;
            UserHubModel receiver;
            
            if (Users.TryGetValue(userName, out receiver))
            {
                var mime = "image/jpeg";
                var model = new CaptureSessionViewModel
                {
                    Photograph = captureSession.Photograph?.ToWebImage(mime),
                    RightThumb = captureSession.RightThumbImage?.ToWebImage(mime),
                    RightIndex = captureSession.RightIndexImage?.ToWebImage(mime),
                    LeftThumb = captureSession.LeftThumbImage?.ToWebImage(mime),
                    LeftIndex = captureSession.LeftIndexImage?.ToWebImage(mime)
                };
                receiver.ConnectionIds.ToList().ForEach(async id =>
                {
                    await hubContext.Clients.Client(id).SendAsync("NotifyNewCapture", model);
                });
            }
        }

    }
}