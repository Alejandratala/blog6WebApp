using System.Collections.Generic;
using System.Threading.Tasks;

namespace blog6WebApp
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<User>> GetUsersAsync(string query);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(string id);
        Task AddUserAsync(User item);
        Task UpdateUserAsync(string id, User item);
        Task DeleteUserAsync(string id);
    }
}