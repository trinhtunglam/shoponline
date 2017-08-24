using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using AutoMapper;
using SHOP2017.Model;
using DOMAIN;

namespace SHOP2017.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var result = _productService.GetAll();
            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(result);
            return model;
        }
    }
}