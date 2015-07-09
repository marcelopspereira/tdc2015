using System;
using Store.Common.Domain.Model;

namespace Store.Venda.Core.Domain.Model
{
	public class Produto: Entity
	{
		public double Preco { get; private set; }
		
		public Produto(double preco):base(Guid.NewGuid())
		{
			this.Preco = preco;
		}
	}
}