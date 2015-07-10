using Fact.Factory;
using Store.Venda.Core.Domain.Model;

namespace Store.Venda.Tests
{
	public class VendasFactory
	{
		public static void Build()
		{
			Builder.Current.Set(new Cliente());
			Builder.Current.Set("100", new Produto(100));
			Builder.Current.Set("400", new Produto(400));
			Builder.Current.Set(new Carrinho(Builder.Current.Build<Cliente>().Id));
		}
	}
}