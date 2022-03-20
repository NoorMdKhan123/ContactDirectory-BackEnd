using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        RegisterResponseModel Register(UserRegistration user);

        LoginResponseModel Login(UserLogin userLogin);

        ContactResponseModel AddContact(int UserId, int contactId);

        ContactResponseModel RemoveContact(int userId, int contactId);

        IEnumerable<User> GetContactsByUserName(string name);

        public IEnumerable<User> GetAllUsers();
    }
}
