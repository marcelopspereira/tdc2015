using System;

namespace Store.Sale.Core.Domain.Model
{
	public interface IClienteRepositorio
	{
		Cliente RecuperarPorId(Guid id);
	}
}
