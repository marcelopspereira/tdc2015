using System;

namespace Store.Venda.Core.Domain.Model.Repository
{
	public interface IClienteRepositorio
	{
		Cliente RecuperarPorId(Guid id);
	}
}
