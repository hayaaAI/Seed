using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
   public class DataResult<T>: Result
    {
        public  T Data { set; get; }
    }
}
