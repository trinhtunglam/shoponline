using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SERVICES;
using AutoMapper;
using SHOP2017.Model;
using DOMAIN;

namespace SHOP2017.Areas.Admin.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;
        public ProducerController(IProducerService producerService, IMapper mapper)
        {
            _producerService = producerService;
            this._mapper = mapper;
        }

        public IEnumerable<ProducerViewModel> GetAll()
        {
            var result = _producerService.GetAll();
            var model = _mapper.Map<IEnumerable<Producer>, IEnumerable<ProducerViewModel>>(result);
            return model;
        }
    }
}