using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surveyVSS.model
{
    class SurveyMD
    {
        public string type { get; set; }

        public static implicit operator SurveyMD(string v)
        {
            throw new NotImplementedException();
        }
    }
}
