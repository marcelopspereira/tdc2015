using System;

namespace DDDStoreExemple.Sale.Core.Domain.Model
{
	public interface ICustomerRepository
	{
		Customer FindById(Guid customerId);
	}
}
