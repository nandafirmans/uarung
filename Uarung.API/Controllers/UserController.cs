using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IDacUser _dacUser;

        public UserController(IDistributedCache distributedCache, IDacUser dacUser)
        {
            _dacUser = dacUser;
        }

        [HttpGet("{id}")]
        public ActionResult<CollectionResponse<User>> Get(string id)
        {
            var response = new CollectionResponse<User>();

            try
            {
                var users = string.IsNullOrEmpty(id)
                    ? _dacUser.All()
                    : new[] {_dacUser.Single(id)};

                response.Collections = users
                    .Select(u => new User
                    {
                        Email = u.Email,
                        Username = u.Username,
                        Name = u.Name,
                        Gender = u.Gender,
                        Phone = u.Phone,
                        Role = u.Role
                    })
                    .ToList();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpPut]
        public ActionResult<BaseReponse> Update(UserRequest request)
        {
            var response = new BaseReponse();

            try
            {
                var user = _dacUser.Single(request.Id);

                user.Email = request.Email;
                user.Username = request.Username;
                user.Password = Crypt.ToSHA256(request.Password);
                user.Name = request.Name;
                user.Gender = request.Gender;
                user.Phone = request.Phone;
                user.Role = request.Role;

                _dacUser.Update(user);
                _dacUser.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpPost]
        public ActionResult<BaseReponse> Create(UserRequest request)
        {
            var response = new BaseReponse();

            try
            {
                if (_dacUser.Single(u => u.Username.Equals(request.Username)) != null)
                    throw new Exception("username already used");

                if (_dacUser.Single(u => u.Email.Equals(request.Email)) != null)
                    throw new Exception("email already used");

                var user = new Data.Entity.User
                {
                    Id = GenerateId(),
                    Username = request.Username,
                    Password = Crypt.ToSHA256(request.Password),
                    Name = request.Name,
                    Email = request.Email,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Role = request.Role
                };

                _dacUser.Insert(user);
                _dacUser.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<BaseReponse> Delete(string id)
        {
            var response = new BaseReponse();

            try
            {
                var user = _dacUser.Single(id);

                _dacUser.Delete(user);
                _dacUser.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }
    }
}