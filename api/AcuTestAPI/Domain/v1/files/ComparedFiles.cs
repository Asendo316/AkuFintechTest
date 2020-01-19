using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcuTestRestAPI.Domain.v1.files
{
    public class ComparedFiles
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatorId { get; set; }

        public string FirstStudentName { get; set; }

        public string SecondStudentName { get; set; }

        public string FirstStudentFile { get; set; }

        public string SecondStudentFile { get; set; }

        public string PercentageSimilarity { get; set; }
    }
}
