using FitnessPlatform.Models;

namespace FitnessPlatform.Repos.Interfaces
{
    public interface IUserRepository
    {
        //Get All Users
        Task<IEnumerable<User>> GetAllUsers();

        // Get user by id
        Task<User?>GetUserById(int id) ;

        // Get user by email (for login)
        Task<User?>GetUserByEmail(string email);

        // Create new user
        Task<User> CreateUser(User user) ;

        // Update user information
        Task UpdateUser(User user)   ;

        // Delete user
        Task DeleteUser(int id) ;

    }
}
