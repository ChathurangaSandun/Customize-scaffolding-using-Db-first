using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class CompanyUserDocumentType : BaseClass
    {
        [Key]
        public long CompanyUserId { get; set; }
        [Required]
        public int DocumentTypeId { get; set; }

        [ForeignKey("CompanyUserId")]
        [InverseProperty("CompanyUserDocumentType")]
        public CompanyUser CompanyUser { get; set; }
        [ForeignKey("DocumentTypeId")]
        [InverseProperty("CompanyUserDocumentType")]
        public DocumentType DocumentType { get; set; }
    }
}
