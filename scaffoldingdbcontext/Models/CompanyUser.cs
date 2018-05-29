using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class CompanyUser : BaseClass
    {
        public CompanyUser()
        {
            CompanyUserTokenMapping = new HashSet<CompanyUserTokenMapping>();
        }

        [Required]
        public long CompanyId { get; set; }
        [Required]
        public long LoginUserId { get; set; }
        public string ReferenceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column("NIC")]
        [StringLength(12)]
        public string Nic { get; set; }
        [Required]
        public string Address { get; set; }
        [StringLength(100)]
        public string Designation { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public bool? IsAgreementDocument { get; set; }
        public bool? IsRequestLetterDocument { get; set; }
        public bool? IsApplicationDocument { get; set; }
        public bool? IsIdentitiyProofDocument { get; set; }

        [ForeignKey("CompanyId")]
        [InverseProperty("CompanyUser")]
        public Company Company { get; set; }
        [ForeignKey("LoginUserId")]
        [InverseProperty("CompanyUser")]
        public User LoginUser { get; set; }
        [InverseProperty("CompanyUser")]
        public CompanyUserDocumentType CompanyUserDocumentType { get; set; }
        [InverseProperty("CompanyUser")]
        public ICollection<CompanyUserTokenMapping> CompanyUserTokenMapping { get; set; }
    }
}
