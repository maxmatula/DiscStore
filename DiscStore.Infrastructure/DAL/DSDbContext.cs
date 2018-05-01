using DiscStore.Core.Entities;
using DiscStore.Core.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Data.Entity;

namespace DiscStore.Infrastructure.DAL
{
    public class DSDbContext : IdentityDbContext<AppUser>
    {
        public DSDbContext() : base("DSDbContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class DSUserStore : UserStore<AppUser>
    {
        public DSUserStore(DSDbContext context) : base(context)
        {

        }
    }

    public class DSUserManager : UserManager<AppUser>
    {
        public DSUserManager(IUserStore<AppUser> store) : base(store)
        {

        }

        public static DSUserManager Create(IdentityFactoryOptions<DSUserManager> options, IOwinContext context)
        {
            var store = new UserStore<AppUser>(context.Get<DSDbContext>());

            var manager = new DSUserManager(store);

            return manager;
        }

    }

    public class DSSignInManager : SignInManager<AppUser, string>
    {
        public DSSignInManager(DSUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {

        }

        public static DSSignInManager Create(IdentityFactoryOptions<DSSignInManager> options, IOwinContext context)
        {
            return new DSSignInManager(context.GetUserManager<DSUserManager>(), context.Authentication);
        }
    }
}
