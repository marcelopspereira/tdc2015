using System;

namespace Store.Venda.Core.Domain.Model
{
    public class Item
    {
        public Guid Id { get; private set; }
        public double Preco { get; private set; }

        public Item(double preco)
        {
            this.Id = Guid.NewGuid();
            this.Preco = preco;
        }
    }
}