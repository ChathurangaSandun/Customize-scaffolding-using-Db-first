using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class Company : BaseClass
    {
        public Company()
        {
            CompanyUser = new HashSet<CompanyUser>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [StringLength(100)]
        public string TypeOfBussiness { get; set; }
        [StringLength(50)]
        public string TaxIdentificationNumber { get; set; }
        [Column("VATRegistrationNumber")]
        [StringLength(50)]
        public string VatregistrationNumber { get; set; }
        [StringLength(50)]
        public string BusinessRegistrationNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfEstablishment { get; set; }
        public bool? ProgressStatus { get; set; }
        public string StatusDescription { get; set; }
        [Required]
        public long CreatedBy { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }

        [InverseProperty("Company")]
        public CompanyDocumentType CompanyDocumentType { get; set; }
        [InverseProperty("Company")]
        public ICollection<CompanyUser> CompanyUser { get; set; }
    }
}
