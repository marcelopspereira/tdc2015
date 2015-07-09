using System;
using System.Linq.Expressions;
using Store.Common.Domain.Model;

namespace Store.Venda.Core.Domain.Model.Specs
{
    public static class ClienteSpec
    {
        public static Expression<Func<Endereco, bool>> EnderecoDeEntrega()
        {
            return x => x.EnderecoEntrega == true;
        }
    }
}