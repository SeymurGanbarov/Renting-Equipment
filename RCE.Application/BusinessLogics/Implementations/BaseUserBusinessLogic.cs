using System;
using System.Collections.Generic;
using AutoMapper;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Domain;

namespace RCE.Application.BusinessLogics
{
    public class BaseUserBusinessLogic : IUserBusinessLogic
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserRepository _userRepository;

        public BaseUserBusinessLogic(IUserQueryService userQueryService, IUserRepository userRepository)
        {
            _userQueryService = userQueryService;
            _userRepository = userRepository;
        }

        public virtual IEnumerable<UserDTO> GetAll()
        {
            return _userQueryService.GetAll();
        }

        public virtual UserDTO GetById(Guid id)
        {
            var entity = _userRepository.FindById(id);
            return Mapper.Map<UserDTO>(entity);
        }

        public virtual void Remove(Guid id)
        {
            _userRepository.Remove(id);
        }

        public virtual UserDTO Save(UserDTO dto)
        {
            var entity = Mapper.Map<User>(dto);
            var savedItem= _userRepository.Save(entity);
            return Mapper.Map<UserDTO>(savedItem);
        }
    }
}
