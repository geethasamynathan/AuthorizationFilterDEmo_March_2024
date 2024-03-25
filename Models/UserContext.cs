using Microsoft.EntityFrameworkCore;

namespace AuthorizationFilterDEmo.Models
{
    public class UserContext :DbContext  
    {
        //public UserContext()
        //{
            
        //}
        public UserContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}

}
