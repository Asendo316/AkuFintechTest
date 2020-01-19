using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Contracts.v1.Requests.user.fileupload
{
    public class CompareFileRequest
    {
        [BindRequired]
        public string FirstStudentName { get; set; }
        [BindRequired]
        public IFormFile FirstStudentFile { get; set; }
        [BindRequired]
        public string SecondStudentName { get; set; }
        [BindRequired]
        public IFormFile SecondStudentFile { get; set; }
    }
}
