using System.Threading.Tasks;

namespace Dryva.Security.Repositories
{
    public interface IDbSeeder
    {
        void CreateAdminCredentials();
    }
}