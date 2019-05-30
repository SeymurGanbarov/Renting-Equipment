﻿using RCE.Application.DTOs;
using RCE.Commons.Abstracts;

namespace RCE.Application.QueryServices
{
    public interface IUserQueryService : IEntityQueryService<UserDTO>
    { }
}