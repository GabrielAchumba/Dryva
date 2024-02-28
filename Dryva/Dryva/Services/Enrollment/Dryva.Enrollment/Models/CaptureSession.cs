using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Models
{
    public class CaptureSession : EntityBase
    {
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
    }
}
