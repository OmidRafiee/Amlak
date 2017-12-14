using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Amlak.Core.Entities
{
    public class Role : IdentityRole<int>
    {
        public override int Id { get; set; }

        public virtual ICollection<IdentityRoleClaim<int>> Claims { get; } = new List<IdentityRoleClaim<int>>();

        public virtual ICollection<IdentityUserRole<int>> Users { get; } = new List<IdentityUserRole<int>>();
    }
}
