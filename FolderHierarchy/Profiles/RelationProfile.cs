using AutoMapper;
using FolderHierarchy.Dtos;
using FolderHierarchy.Entities;

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
