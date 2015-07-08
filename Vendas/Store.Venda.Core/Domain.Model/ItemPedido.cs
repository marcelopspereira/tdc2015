using System;
using Store.Common.Domain.Model;

namespace Store.Venda.Core.Domain.Model
{
    public class ItemPedido: ValueObject
    {
        public Guid Id { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }

        public ItemPedido(Produto produto, int quantidade)
        {
            this.Id = Guid.NewGuid();
            this.Produto = produto;
            this.Quantidade = quantidade;
        }
        
        internal void IncrementarQuantidade(int quantidade)
        {
            this.Quantidade += quantidade;
        }
        
        internal void DiminuirQuantidade(int quantidade)
        {
            this.Quantidade -= quantidade;
        }        
    }
}