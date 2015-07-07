using Store.Sale.Core.Domain.Model;

namespace Store.Sale.Core.Application
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