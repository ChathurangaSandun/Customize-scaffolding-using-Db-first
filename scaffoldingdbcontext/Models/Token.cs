using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class Token : BaseClass
    {
        public Token()
        {
            CompanyUserTokenMapping = new HashSet<CompanyUserTokenMapping>();
        }

        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        public string SerialNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Price { get; set; }

        [InverseProperty("Token")]
        public ICollection<CompanyUserTokenMapping> CompanyUserTokenMapping { get; set; }
    }
}
