using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using AutoMapper;
using DOMAIN;
using SHOP2017.Model;

namespace SHOP2017.Controllers
{
    public class ProductBTController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductBTController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var result = _productService.GetAll();
            var model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(result);
            return View(model);
        }
    }
}