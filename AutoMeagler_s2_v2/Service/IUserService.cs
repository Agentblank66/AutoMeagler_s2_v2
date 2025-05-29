using AutoMeagler_s2_v2.Models;

namespace AutoMeagler_s2_v2.Service
{
    public interface IUserService
    {
        /// <summary>
        /// methods for the user service
        /// </summary>
        public void AddUser<T>(T user) where T : User;

        public void DeleteUser<T>(T user) where T : User;

        public void UpdateUser(User user);

        public User GetUser(int id, User.UserType? user);

        public List<User> SearchbyName(string name);

    }
}
