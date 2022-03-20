using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
         IUserRL _userRL;
        public UserBL(IUserRL userRL)
        {
            _userRL = userRL;
        }

        public RegisterResponseModel Register(UserRegistration user)
        {
            return this._userRL.Register(user);
        }
        public LoginResponseModel Login(UserLogin userLogin)
        {
            return this._userRL.Login(userLogin);
        }

        public ContactResponseModel AddContact(int UserId, int contactId)
        {
            return this._userRL.AddContact(UserId, contactId);
        }
        public ContactResponseModel RemoveContact(int userId, int contactId)
        {
            return this._userRL.RemoveContact(userId, contactId);
        }
        public IEnumerable<User> GetContactsByUserName(string name)
        {
            return this._userRL.GetContactsByUserName(name);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRL.GetAllUsers();
        }



    }
}
