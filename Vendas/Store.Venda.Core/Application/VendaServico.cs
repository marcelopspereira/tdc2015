using Store.Venda.Core.Domain.Model.Repository;

namespace Store.Venda.Core.Application
{
    public class VendaServico
    {
        private readonly IClienteRepositorio clienteRepositorio;

        public VendaServico(IClienteRepositorio clienteRepositorio)
        {
            this.clienteRepositorio = clienteRepositorio;
        }
    }
}