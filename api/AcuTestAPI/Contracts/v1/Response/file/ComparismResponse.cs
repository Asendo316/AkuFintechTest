using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Contracts.v1.Response.file
{
    public class ComparismResponse
    {
        public string FirstStudentName { get; set; }
        public string FirstStudentFileContent { get; set; }
        public string SecondStudentName { get; set; }
        public string SecondStudentFileContent { get; set; }
        public string PercentageSimilarity { get; set; }

    }
}
