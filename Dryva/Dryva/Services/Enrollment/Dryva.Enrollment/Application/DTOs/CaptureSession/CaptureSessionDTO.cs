using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.CaptureSession
{
    public class CaptureSessionDTO : NewCaptureSessionDTO
    {
        public Guid Id { get; set; }
    }
    public class NewCaptureSessionDTO
    {
        public int DataType { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
