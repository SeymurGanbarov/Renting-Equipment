using RCE.Application.Services;
using RCE.Commons;
using RCE.UI.Models;
using Resources=RCE.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using RCE.Application.DTOs;

namespace RCE.UI.Services
{
    public class UserServiceFacade
    {
        private readonly IUserService _userService;

        public UserServiceFacade(IUserService userService)
        {
            _userService = userService;
        }

        public LogicResult<UserDTO> Login(UserLoginModel model)
        {
            var result = _userService.GetAll();
            if (result.IsSucceed)
            {
                var user = result.Data.FirstOrDefault(m => m.Email == model.Email);
                if (user != null)
                {
                    var response = Crypto.VerifyHashedPassword(user.Password, model.Password) ? LogicResult<UserDTO>.Succeed(user) : LogicResult<UserDTO>.Failure(Resources.Validation.InvalidEmailOrPassword);
                    return response;
                }
                else return LogicResult<UserDTO>.Failure(Resources.Validation.InvalidEmailOrPassword);
            }
            else return LogicResult<UserDTO>.Failure(Resources.Validation.UnSuccessfullOperation);
        }

    }
}