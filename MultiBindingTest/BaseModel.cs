using System;
using System.Collections.Generic;
using System.Text;

namespace MultiBindingTest
{
    public class BaseModel
    {
        //멀티 바인딩을 위한 프로퍼티 부분
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
    }
}
