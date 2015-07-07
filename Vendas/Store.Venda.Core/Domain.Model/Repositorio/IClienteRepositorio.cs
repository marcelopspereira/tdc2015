using System;

namespace Store.Venda.Core.Domain.Model
{
	public interface IClienteRepositorio
	{
		Cliente RecuperarPorId(Guid id);
	}
}
