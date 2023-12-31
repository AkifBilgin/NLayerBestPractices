using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerBestPractices.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string error): base(error) 
        {
            
        }
    }
}
