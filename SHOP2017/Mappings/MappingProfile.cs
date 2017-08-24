using DOMAIN;
using SHOP2017.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOP2017.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
            CreateMap<SupplierViewModel, Supplier>().ReverseMap();
            CreateMap<ProductCategoryViewModel, ProductCategory>().ReverseMap();
            CreateMap<ProducerViewModel, Producer>().ReverseMap();
        }
    }
}
