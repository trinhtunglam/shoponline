using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using AutoMapper;
using DOMAIN;
using SHOP2017.Model;
using Newtonsoft.Json;

namespace SHOP2017.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper)
        {
            this._productCategoryService = productCategoryService;
            this._mapper = mapper;
        }
        [Route("admin/productct")]
        public IActionResult Index()
        {
            var model = _productCategoryService.GetAll();
            var result = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return View(result);
        }
        
        [HttpPost]
        [Route("admin/productct/create")]
        public IActionResult Create(string model)
        {
            ProductCategoryViewModel productCategoryVm = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductCategoryViewModel>(model);
            var result = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryService.Create(result);
            return Json(new
            {
                status=true
            });
        }

        [Route("admin/productct/getbyid")]
        public IActionResult GetById(int id)
        {
            var model = _productCategoryService.GetById(id);
            var result = _mapper.Map<ProductCategory, ProductCategoryViewModel>(model);
            if (result != null)
            {
                return Json(new
                {
                    status = true,
                    data = result
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message="Dữ liệu không có"
                });
            }
            
        }

        [HttpPost]
        [Route("admin/productct/update")]
        public IActionResult Update(string model)
        {
            ProductCategoryViewModel productCategoryVm = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductCategoryViewModel>(model);
            var result = _mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryService.Edit(result);
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        [Route("admin/productct/delete")]
        public IActionResult Delete(int id)
        {
            _productCategoryService.Delete(id);
            return Json(new
            {
                status = true
            });
        }

    }
}