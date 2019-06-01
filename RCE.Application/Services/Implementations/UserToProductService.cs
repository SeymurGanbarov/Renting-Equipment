using RCE.Application.BusinessLogics;
using RCE.Application.DTOs;
using RCE.Commons;
using System;
using System.Collections.Generic;

namespace RCE.Application.Services
{
    public class UserToProductService : IUserToProductService
    {
        private readonly IUserToProductBusinessLogic _userToProductBusinessLogic;

        public UserToProductService(IUserToProductBusinessLogic userToProductBusinessLogic)
        {
            _userToProductBusinessLogic = userToProductBusinessLogic;
        }

        public LogicResult<IEnumerable<UserToProductDTO>> GetAll()
        {
            try
            {
                var users = _userToProductBusinessLogic.GetAll();
                return LogicResult<IEnumerable<UserToProductDTO>>.Succeed(users);
            }
            catch (Exception exception)
            {
                return LogicResult<IEnumerable<UserToProductDTO>>.Failure(exception);
            }
        }

        public LogicResult<UserToProductDTO> GetById(Guid id)
        {
            try
            {
                var entity = _userToProductBusinessLogic.GetById(id);
                return LogicResult<UserToProductDTO>.Succeed(entity);
            }
            catch (Exception exception)
            {
                return LogicResult<UserToProductDTO>.Failure(exception);
            }
        }

        public LogicResult Remove(Guid id)
        {
            try
            {
                _userToProductBusinessLogic.Remove(id);
                return LogicResult.Succeed();
            }
            catch (Exception exception)
            {
                return LogicResult.Failure(exception);
            }
        }

        public LogicResult<UserToProductDTO> Save(UserToProductDTO entity)
        {
            try
            {
                var dto= _userToProductBusinessLogic.Save(entity);
                return LogicResult<UserToProductDTO>.Succeed(dto);
            }
            catch (Exception exception)
            {
                return LogicResult<UserToProductDTO>.Failure(exception);
            }
        }
    }
}
