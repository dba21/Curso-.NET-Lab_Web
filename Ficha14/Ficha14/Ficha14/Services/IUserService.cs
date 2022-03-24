using Ficha14.Models;

namespace Ficha14.Services
{
    public interface IUserService
    {
        public abstract User Get(string UserName, string Password);

        public abstract User Create(User newUser);

        public abstract User GetByName(string UserName);
    }
}
