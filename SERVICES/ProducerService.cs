using DATA.Repositories;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICES
{
    public partial interface IProducerService
    {
        IEnumerable<Producer> GetAll();
    }
    public partial class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            this._producerRepository = producerRepository;
        }

        public IEnumerable<Producer> GetAll()
        {
            return _producerRepository.GetAll();
        }
    }
}
