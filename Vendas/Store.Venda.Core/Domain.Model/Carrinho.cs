using System;
using System.Linq;
using System.Collections.Generic;

namespace Store.Venda.Core.Domain.Model
{
	public class Carrinho
	{
		public Cliente Cliente { get; private set; }
		public ICollection<Item> Itens { get; private set; }
		public Guid UltimoItemLancado { get; private set; }
		
		public Carrinho(Cliente cliente)
		{
			this.Cliente = cliente;
			this.Itens = new List<Item>();
		}
		
		public void AdicionarItem(Item item)
		{
			Itens.Add(item);
			UltimoItemLancado = item.Id;
		}
		
		public void RemoverItem(Guid id)
		{
			var item = this.Itens.Where(x => x.Id == id).FirstOrDefault();
			Itens.Remove(item);
		}
		
		public double Calcular()
		{
			return Itens.Sum(x => x.Preco);
		}
	}
}