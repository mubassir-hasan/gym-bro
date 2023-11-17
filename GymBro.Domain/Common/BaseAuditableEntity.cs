using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Common
{
    public class BaseAuditableEntity
    {
        [MaxLength(100)]
        public string? CreatedByUserId { get; set; }

        public DateTime CreateDateUtc { get; set; }

        [MaxLength(100)]
        public string? ModifiedByUserId { get; set; }

        public DateTime ModifiedDateUtc { get; set; }
    }
}
