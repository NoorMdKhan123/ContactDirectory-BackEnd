using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        UserContext _context;
        IConfiguration _configuration;

        public UserRL(UserContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public RegisterResponseModel Register(UserRegistration user)
        {
            if(user != null)
            {
                User newUser = new User();
                newUser.UserName = user.UserName;
                newUser.Age = user.Age;
                newUser.Department = user.Department;
                newUser.DateOfBirth = user.DateOfBirth;
                newUser.Phone = user.Phone;
                newUser.Location = user.Location;
                newUser.Email = user.Email;
                newUser.Gender = user.Gender;
                newUser.Password = SecureData.ConvertToEncrypt(user.Password);
                this._context.Users.Add(newUser);
                var result = this._context.SaveChanges();
                RegisterResponseModel registerResponseModel = new RegisterResponseModel();
                registerResponseModel.Age = newUser.Age;
                registerResponseModel.Department = newUser.Department;  
                registerResponseModel.DateOfBirth = newUser.DateOfBirth;
                registerResponseModel.Phone = newUser.Phone;
                registerResponseModel.Location = newUser.Location;
                registerResponseModel.Email = newUser.Email;
                registerResponseModel.Gender = newUser.Gender;

                if (result > 0)
                {
                    return registerResponseModel;
                }
                throw new InvalidOperationException("data not saved");

            }
            throw new ArgumentNullException("no data present");
        }

        public string GenerateJWTToken(string Email, int UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Email,Email),
                   new Claim("UserId",UserId.ToString())
            };


          var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        _configuration["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public LoginResponseModel Login(UserLogin userLogin)
        {
              User validLogin = this._context.Users.Where
                (x => x.Email == userLogin.Email).FirstOrDefault();
            if (validLogin != null)
            {
                if(SecureData.ConvertToDecrypt(validLogin.Password) == userLogin.Password)
                {
                    LoginResponseModel loginResponseModel = new LoginResponseModel();
                    string token = "";
                    token = GenerateJWTToken(validLogin.Email, validLogin.UserId);
                    loginResponseModel.Email = validLogin.Email;
                    loginResponseModel.UserId = validLogin.UserId;
                    loginResponseModel.Department=validLogin.Department;
                    loginResponseModel.UserName = validLogin.UserName;
                    loginResponseModel.PhoneNumber = validLogin.Phone;
                    loginResponseModel.Gender = validLogin.Gender;
                    loginResponseModel.DateOfBirth = (DateTime)validLogin.DateOfBirth;
                    loginResponseModel.Token = token;
                    return loginResponseModel;
                }
                throw new KeyNotFoundException("Password is incorrect");
            }
            throw new KeyNotFoundException("Email doesn't exsist");
        }

        public ContactResponseModel AddContact(int UserId, int contactId)
        {
            if(UserId != 0 && contactId != 0)
            {
                var data = this._context.Users.Where(s => s.UserId == UserId).FirstOrDefault();
                if (data != null)
                {
                    ContactData contactData = new ContactData();
                    contactData.ContactId = contactId;
                    contactData.UserId = UserId;
                    this._context.ContactData.Add(contactData);
                    var result = this._context.SaveChanges();
                    ContactResponseModel model = new ContactResponseModel();
                    model.UserId = UserId;
                    model.ContactId = contactId;
                    if (result > 0)
                    {
                       
                        return model;
                    }
                    else
                    {
                        return model;
                    }

                }
                throw new InvalidOperationException("data is empty");
            }
            throw new ArgumentNullException("No data present");
        }

        public ContactResponseModel RemoveContact(int userId, int contactId)
        {
            if (userId != 0 && contactId != 0)
            {
                var data = this._context.ContactData.Where(s => s.ContactId == contactId && s.UserId == userId).FirstOrDefault();
                if(data != null)
                {
                    this._context.ContactData.Remove(data);
                    var result = this._context.SaveChanges();
                    
                    ContactResponseModel model = new ContactResponseModel();
                    model.UserId = userId;
                    model.ContactId = contactId;
                    if (result > 0)
                    {
                        return model;
                    }
                    throw new InvalidOperationException("Data not removed");
                }
                throw new Exception("contactid is not present");

            }
            throw new ArgumentNullException("Id's are  null");

        }

        public IEnumerable<User> GetContactsByUserName(string name)
        {
            if(name != null)
            {
                IEnumerable<User> validContact = this._context.Users.Where(s => s.UserName == name);
                
                if (validContact != null)
                {

                    return validContact;
                }
                throw new InvalidOperationException("contacts not fetched from database");
            }
            throw new ArgumentNullException("userid is empty");
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this._context.Users.ToList();
        }

    }
}
