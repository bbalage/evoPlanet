using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface IUserApiService
    {
        List<User> GetAllUsers();

        void SaveData(List<User> users);

        void AddUser(User newUser);

        void UpdateUser(int userId, User updatedUser);

        void DeleteUser(int userId);
    }
}
