using AutoMapper;
using hachathon.Domain.Models;
using hachathon.Resource;

namespace hachathon.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Plan, PlanResource>();
            CreateMap<Status, StatusResource>();
            CreateMap<Phone, PhoneResource>();
        }
    }
    
    public class ResourceToModeProfile : Profile
    {
        public ResourceToModeProfile()
        {
            CreateMap<PlanResource, Plan>();
            CreateMap<StatusResource, Status>();
            CreateMap<PhoneResource, Phone>();
        }
    }
}