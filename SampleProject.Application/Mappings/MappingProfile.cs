using AutoMapper;
using SampleProject.Application.ViewModels;
using SampleProject.Domain;

namespace SampleProject.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
