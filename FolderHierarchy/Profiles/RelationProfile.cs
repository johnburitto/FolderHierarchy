using AutoMapper;
using FolderHierarchy.Dtos;
using FolderHierarchy.Models;

namespace FolderHierarchy.Profiles
{
    public class RelationProfile : Profile
    {
        public RelationProfile() 
        {
            CreateMap<RelationCreateDto, HierarchyRelation>();
        }
    }
}
