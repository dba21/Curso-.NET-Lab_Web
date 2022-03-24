using Ficha14.Models;

namespace Ficha14.Services
{
    public class UserService : IUserService

    {
        private readonly UserContext context;

        public UserService(UserContext context)
        {
            this.context = context;
        }
        public User Create(User newUser)
        {

                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser;
            
        }

        public User Get(string UserName, string Password)
        {
            var user = context.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            return user;
        }

        public User GetByName(string UserName)
        {
            var user = context.Users.FirstOrDefault(x => x.UserName == UserName );
            return user;
        }
    }
}
