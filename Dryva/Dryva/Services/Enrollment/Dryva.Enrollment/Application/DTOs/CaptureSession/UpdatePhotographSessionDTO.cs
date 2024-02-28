using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.DTOs.CaptureSession
{
    public class UpdatePhotographSessionDTO : NewUpdatePhotographSessionDTO
    {
        public Guid Id { get; set; }
    }
    public class NewUpdatePhotographSessionDTO
    {
        public byte[] Photograph { get; set; }
    }
}
