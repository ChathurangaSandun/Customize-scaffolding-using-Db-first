using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class DocumentType : BaseClass
    {
        public DocumentType()
        {
            CompanyDocumentType = new HashSet<CompanyDocumentType>();
            CompanyUserDocumentType = new HashSet<CompanyUserDocumentType>();
        }

        [StringLength(500)]
        public string DocumentName { get; set; }
        [Required]
        public bool IsCompanyDocument { get; set; }
        [Required]
        public bool IsUserDocument { get; set; }
        [Required]
        public bool IsRequired { get; set; }

        [InverseProperty("DocumentType")]
        public ICollection<CompanyDocumentType> CompanyDocumentType { get; set; }
        [InverseProperty("DocumentType")]
        public ICollection<CompanyUserDocumentType> CompanyUserDocumentType { get; set; }
    }
}
