using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Core.Enums;

namespace backend.Core.Dtos.Job
{
    public class JobGetDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public JobLevl Level { get; set; }

        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}