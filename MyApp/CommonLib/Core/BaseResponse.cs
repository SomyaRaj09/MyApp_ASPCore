using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Core
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }

        
    }
}
