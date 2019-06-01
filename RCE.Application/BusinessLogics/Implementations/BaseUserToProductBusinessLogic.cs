using System;
using System.Collections.Generic;
using AutoMapper;
using RCE.Application.DTOs;
using RCE.Application.QueryServices;
using RCE.Application.Repositories;
using RCE.Domain;

namespace RCE.Application.BusinessLogics
{
    public class BaseUserToProductBusinessLogic : IUserToProductBusinessLogic
    {
        private readonly IUserToProductQueryService _userToProductQueryService;
        private readonly IUserToProductRepository _userToProductRepository;

        public virtual IEnumerable<UserToProductDTO> GetAll()
        {
            return _userToProductQueryService.GetAll();
        }

        public UserToProductDTO GetById(Guid id)
        {
            var entity = _userToProductRepository.FindById(id);
            return Mapper.Map<UserToProductDTO>(entity);
        }

        public void Remove(Guid id)
        {
            _userToProductRepository.Remove(id);
        }

        public UserToProductDTO Save(UserToProductDTO dto)
        {
            var entity = Mapper.Map<UserToProduct>(dto);
            var savedItem=_userToProductRepository.Save(entity);
            return Mapper.Map<UserToProductDTO>(savedItem);
        }
    }
}
