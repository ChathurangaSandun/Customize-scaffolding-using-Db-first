using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class CompanyUserTokenMapping : BaseClass
    {
        [Required]
        public long CompanyUserId { get; set; }
        [Required]
        public long TokenId { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime IssueDate { get; set; }
        [StringLength(50)]
        public string Issurer { get; set; }

        [ForeignKey("CompanyUserId")]
        [InverseProperty("CompanyUserTokenMapping")]
        public CompanyUser CompanyUser { get; set; }
        [ForeignKey("TokenId")]
        [InverseProperty("CompanyUserTokenMapping")]
        public Token Token { get; set; }
    }
}
