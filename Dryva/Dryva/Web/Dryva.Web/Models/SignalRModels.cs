using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dryva.Web.Models
{
    public class UserHubModel
    {
        public string UserName { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }

    public class CaptureSessionViewModel
    {
        public string Photograph { get; set; }
        public string RightThumb { get; set; }
        public string RightIndex { get; set; }
        public string LeftThumb { get; set; }
        public string LeftIndex { get; set; }
    }

    public class CaptureSessionDTO
    {
        public Guid Id { get; set; }

        public byte[] Photograph { get; set; }
        public byte[] RightThumbMinutia { get; set; }
        public byte[] RightThumbImage { get; set; }
        public byte[] RightIndexMinutia { get; set; }
        public byte[] RightIndexImage { get; set; }
        public byte[] LeftThumbMinutia { get; set; }
        public byte[] LeftThumbImage { get; set; }
        public byte[] LeftIndexMinutia { get; set; }
        public byte[] LeftIndexImage { get; set; }
        public byte[] Signature { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
