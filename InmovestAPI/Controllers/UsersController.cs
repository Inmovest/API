﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Inmovest.API.Domain;
using Inmovest.API.Domain.Services;
using Inmovest.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Inmovest.API.Controllers
{
    
    [ApiController]
    [Route("/api/v1/[controller]")]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();

            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            
            return resources;
        }
    }
}