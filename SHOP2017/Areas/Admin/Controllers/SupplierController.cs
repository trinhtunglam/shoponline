using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using AutoMapper;
using DOMAIN;
using SHOP2017.Model;

namespace SHOP2017.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            this._supplierService = supplierService;
            this._mapper = mapper;
        }
        [Route("admin/supplier")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;

            var viewModel = new SupplierViewModel();
            viewModel.Tests = _supplierService.GetPaging(pageNumber, pageSize);

            var result = _supplierService.GetAll();
            var model = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(result);
            return View(viewModel);
        }
    }
}