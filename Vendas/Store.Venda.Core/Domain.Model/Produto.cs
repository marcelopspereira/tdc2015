using System;
using Store.Common.Domain.Model;

namespace Store.Venda.Core.Domain.Model
{
	public class Produto: ValueObject
	{
		public Guid Id { get; private set; }
		public double Preco { get; private set; }
		
		public Produto(double preco)
		{
			this.Id = Guid.NewGuid();
			this.Preco = preco;
		}
	}
}