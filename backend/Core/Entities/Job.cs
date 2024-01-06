using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Core.Enums;

namespace backend.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public JobLevl Level { get; set; }

        // relations
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }

}