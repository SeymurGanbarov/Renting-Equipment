using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCE.Application.BusinessLogics;
using RCE.Application.DTOs;
using RCE.Commons;

namespace RCE.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public UserService(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        public LogicResult<IEnumerable<UserDTO>> GetAll()
        {
            try
            {
                var users = _userBusinessLogic.GetAll();
                return LogicResult<IEnumerable<UserDTO>>.Succeed(users);
            }
            catch (Exception exception)
            {
                return LogicResult<IEnumerable<UserDTO>>.Failure(exception);
            }
        }

        public LogicResult<UserDTO> GetById(Guid id)
        {
            try
            {
                var entity = _userBusinessLogic.GetById(id);
                return LogicResult<UserDTO>.Succeed(entity);
            }
            catch (Exception exception)
            {
                return LogicResult<UserDTO>.Failure(exception);
            }
        }

        public LogicResult Remove(Guid id)
        {
            try
            {
                _userBusinessLogic.Remove(id);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }

        public LogicResult Save(UserDTO entity)
        {
            try
            {
                _userBusinessLogic.Save(entity);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }
    }
}
