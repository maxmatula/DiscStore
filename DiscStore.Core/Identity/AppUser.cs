using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Core.Identity
{
    public class AppUser : IdentityUser
    {
        [DataType(DataType.Text)]
        [StringLength(40)]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [StringLength(40)]
        public string Surname { get; set; }
    }
}
