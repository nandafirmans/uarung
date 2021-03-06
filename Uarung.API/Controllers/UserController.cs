﻿using System;
using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult<CollectionResponse<User>> Get()
        {
            var response = new CollectionResponse<User>();

            try
            {
                response.Collections = TranslateToModel(_dacUser.All());
                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        [CashierAllowed]
        [HttpGet("{id}")]
        public ActionResult<CollectionResponse<User>> GetSingle(string id)
        {
            var response = new CollectionResponse<User>();

            try
            {
                response.Collections = TranslateToModel(new[] { _dacUser.Single(id) });
                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpPut]
        public ActionResult<BaseResponse> Update(User request)
        {
            var response = new BaseResponse();

            try
            {
                var user = _dacUser.Single(request.Id);

                if (user.Email != request.Email && !string.IsNullOrEmpty(request.Email))
                    user.Email = request.Email;

                if (user.Username != request.Username && !string.IsNullOrEmpty(request.Username))
                    user.Username = request.Username;

                if (user.Password != request.Password && !string.IsNullOrEmpty(request.Password))
                {
                    var passwordHash = Crypt.ToSHA256(request.Password);

                    if(user.Password != passwordHash)
                        user.Password = passwordHash;
                }

                if(user.Name != request.Name && !string.IsNullOrEmpty(request.Name))
                    user.Name = request.Name;

                if (user.Gender != request.Gender && request.Gender != char.MinValue)
                    user.Gender = request.Gender;

                if(user.Phone != request.Phone && !string.IsNullOrEmpty(request.Phone))
                    user.Phone = request.Phone;

                if (user.Role != request.Role && !string.IsNullOrEmpty(request.Role))
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
        public ActionResult<BaseResponse> Create(User request)
        {
            var response = new BaseResponse();

            try
            {
                request.Id = GenerateId();
                Shared.CreateUser(request, _dacUser);

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<BaseResponse> Delete(string id)
        {
            var response = new BaseResponse();

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

        private List<User> TranslateToModel(IEnumerable<Data.Entity.User> users)
        {
            return users
                .Select(u => new User
                {
                    Id = u.Id,
                    Email = u.Email,
                    Username = u.Username,
                    Name = u.Name,
                    Gender = u.Gender,
                    Phone = u.Phone,
                    Role = u.Role,
                    Password = u.Password
                })
                .ToList();
        }
    }
}