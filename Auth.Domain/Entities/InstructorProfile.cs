using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class InstructorProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? ProfileImage { get; set; }
        public int YearsOfExperience { get; set; }
        public string? ResumeUrl { get; set; }
        public InstructorStatus Status { get; set; }
    }

    public enum InstructorStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }

}
