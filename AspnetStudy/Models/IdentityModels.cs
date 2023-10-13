using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspnetStudy.Models
{
    // ApplicationUser 클래스에 더 많은 속성을 추가하여 사용자의 프로필 데이터를 추가할 수 있습니다. 자세한 내용은 https://go.microsoft.com/fwlink/?LinkID=317594를 참조하세요.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // authenticationType은 CookieAuthenticationOptions.AuthenticationType에 정의된 항목과 일치해야 합니다.
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 여기에 사용자 지정 사용자 클레임 추가
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
    {
        /* 고객 테이블 */
        public DbSet<Customer> Customers { get; set; }
        // 고객 테이블에서 참조하는 멤버십 테이블
        public DbSet<MembershipType> MembershipTypes { get; set; }

        /* 영화 테이블*/
        public DbSet<Movie> Movies { get; set; }
        // 영화 테이블에서 참조하는 장르 테이블
        public DbSet<Genre> Genres { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}