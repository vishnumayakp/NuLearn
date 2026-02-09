using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities
{
    public class AuditableEntity
    {
        public Guid? Created_By { get; set; }
        public DateTime Created_At { get; set; }
        public Guid? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool IsActive { get; set; }
    }
}
