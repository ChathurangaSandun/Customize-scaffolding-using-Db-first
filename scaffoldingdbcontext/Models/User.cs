using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaffoldingdbcontext.Models
{
    public partial class User : BaseClass
    {
        public User()
        {
            CompanyUser = new HashSet<CompanyUser>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public bool Type { get; set; }

        [InverseProperty("LoginUser")]
        public ICollection<CompanyUser> CompanyUser { get; set; }
    }
}
