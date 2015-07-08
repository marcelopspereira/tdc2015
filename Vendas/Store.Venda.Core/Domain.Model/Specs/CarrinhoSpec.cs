using System;
using System.Linq.Expressions;

namespace Store.Venda.Core.Domain.Model
{
    public static class CarrinhoSpec
    {
        public static Expression<Func<Carrinho, bool>> CarrinhosAbertos()
        {
            return x => x.PedidoGerado == true;
        }

        public static Expression<Func<Carrinho, bool>> CarrinhosCliente(Guid id)
        {
            return x => x.ClienteId == id;
        }
    }
}