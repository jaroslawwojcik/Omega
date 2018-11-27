using AutoMapper;
using Omega.Entities;
using Omega.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omega.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}