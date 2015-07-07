using System;
using System.Linq;
using System.Collections.Generic;

namespace Store.Venda.Core.Domain.Model
{
	public class Carrinho
	{
		public Cliente Cliente { get; private set; }
		public ICollection<Item> Itens { get; private set; }
		
		public Carrinho(Cliente cliente)
		{
			this.Cliente = cliente;
			this.Itens = new List<Item>();
		}
		
		public void AdicionarItem(Item item)
		{
			Itens.Add(item);
		}
		
		public double CalcularTotalItens()
		{
			return Itens.Sum(x => x.Preco);
		}
	}
}