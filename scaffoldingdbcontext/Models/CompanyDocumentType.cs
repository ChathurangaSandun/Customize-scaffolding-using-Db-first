using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class CompanyDocumentType : BaseClass
    {
        [Key]
        public long CompanyId { get; set; }
        [Required]
        public int DocumentTypeId { get; set; }

        [ForeignKey("CompanyId")]
        [InverseProperty("CompanyDocumentType")]
        public Company Company { get; set; }
        [ForeignKey("DocumentTypeId")]
        [InverseProperty("CompanyDocumentType")]
        public DocumentType DocumentType { get; set; }
    }
}
