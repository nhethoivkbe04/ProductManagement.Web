using AutoMapper;
using ProductManagement.Web.DTOs;
using ProductManagement.Web.Models;

namespace ProductManagement.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Các mapping cũ
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            // ✅ Thêm dòng này để fix lỗi
            CreateMap<Product, ProductDeleteDto>().ReverseMap();
        }
    }
}
