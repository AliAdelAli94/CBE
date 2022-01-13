using AutoMapper;
using CBE.Feature.DiscussionForum.BLL.DTOs;
using CBE.Feature.DiscussionForum.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.DiscussionForum.Mappers
{
    public class DiscussionForumMappingProfile : Profile
    {
        public DiscussionForumMappingProfile()
        {
            CreateMap<Topic, TopicDTO>().ReverseMap();
            CreateMap<TopicsComment, TopicsCommentDTO>().ReverseMap();
            CreateMap<TopicsLike, TopicsLikeDTO>().ReverseMap();
            CreateMap<TopicsSubscribe, TopicsSubscribeDTO>().ReverseMap();
        }
    }
}