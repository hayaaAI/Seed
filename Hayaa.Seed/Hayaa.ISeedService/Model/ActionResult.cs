using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ISeedService.Model
{
   public class Result
    {
        public Boolean ActionResult { set; get; }
        public string Message { set; get; }
        public string ResultCode { set; get; }
        public string ErrorCode { set; get; }
    }
}
