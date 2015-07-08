using System;
using System.Linq;
using System.Collections.Generic;
using Store.Common.Domain.Model;
using Store.Common.Validation;

namespace Store.Venda.Core.Domain.Model
{
    public class Carrinho : AggregateRoot
    {
        public Guid Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public ICollection<ItemPedido> Itens { get; private set; }
        public Guid UltimoItemLancado { get; private set; }

        public Carrinho(Cliente cliente)
        {
            this.Id = Guid.NewGuid();
            this.Cliente = cliente;
            this.Itens = new List<ItemPedido>();
        }

        public void AdicionarProduto(Produto produto, int quantidade = 1)
        {
            var item = new ItemPedido(produto, quantidade);
            UltimoItemLancado = item.Id;

            Itens.Add(item);
        }

        public void AumentarQuantidadeItem(Guid id, int quantidade)
        {
            AssertionConcern.AssertNotZeroOrNegative(quantidade, "Informe uma quantidade válida");
            
            var item = this.Itens.Where(x => x.Id == id).FirstOrDefault();
            item.IncrementarQuantidade(quantidade);
        }

        public void DiminuirQuantidadeItem(Guid id, int quantidade)
        {
            AssertionConcern.AssertNotZeroOrNegative(quantidade, "Informe uma quantidade válida");
            
            var item = this.Itens.Where(x => x.Id == id).FirstOrDefault();
            item.DiminuirQuantidade(quantidade);
        }

        public void RemoverItem(Guid id)
        {
            var item = this.Itens.Where(x => x.Id == id).FirstOrDefault();
            Itens.Remove(item);
        }

        public double Calcular()
        {
            return Itens.Sum(x => x.Produto.Preco * x.Quantidade);
        }
    }
}