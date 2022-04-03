using System.Collections.Generic;
using _Core.CrossCuttingConcerns.Logging;

namespace _Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }

        
    }
}
