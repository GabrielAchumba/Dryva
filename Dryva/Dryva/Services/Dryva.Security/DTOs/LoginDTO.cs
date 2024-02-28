using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Security.DTOs
{
    public class LoginDTO<T> : ResponseDTO<T> where T : class
    {
    }
}
