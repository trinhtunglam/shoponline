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
    [Route("api/Supplier")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            this._mapper = mapper;
        }

        public IEnumerable<SupplierViewModel> GetAll()
        {
            var result = _supplierService.GetAll();
            var model = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(result);
            return model;
        }
    }
}