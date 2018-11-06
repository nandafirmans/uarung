using System;
using Uarung.Data.Contract;
using Uarung.Model;

namespace Uarung.API.Utility
{
    public static class Shared
    {
        public static void CreateUser(User request, IDacUser dacUser)
        {
            if (dacUser.Single(u => u.Username.Equals(request.Username)) != null)
                throw new Exception("username already used");

            if (dacUser.Single(u => u.Email.Equals(request.Email)) != null)
                throw new Exception("email already used");

            var user = new Data.Entity.User
            {
                Id = request.Id,
                Username = request.Username,
                Password = Crypt.ToSHA256(request.Password),
                Name = request.Name,
                Email = request.Email,
                Gender = request.Gender,
                Phone = request.Phone,
                Role = request.Role
            };

            dacUser.Insert(user);
            dacUser.Commit();
        }
    }
}