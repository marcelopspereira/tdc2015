using System;
using System.Linq;
using System.Collections.Generic;
using DDDStoreExemple.Sale.Core.Domain.Model;

namespace DDDStoreExemple.Sale.Core.Application
{
    public class SaleService
    {
        private readonly ICustomerRepository customerRepository;

        public SaleService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
    }
}