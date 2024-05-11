using AutoMapper;
using MyReddit.Core.Models;
using MyReddit.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReddit.DataAccess.Mappings
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<PostEntity, Post>();
            CreateMap<TopicEntity, Topic>();
            CreateMap<UserEntity, User>();
        }
    }
}
