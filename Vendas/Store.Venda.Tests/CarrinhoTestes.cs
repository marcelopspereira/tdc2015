using Xunit;
using BetterSpecs;
using Store.Venda.Core.Domain.Model;

namespace Store.Venda.Tests
{
    public class CarrinhoTestes: SpecContext
    {
        [Fact]
        public void AoAdicionarItemNoCarrinho()
        {
            Cliente cliente = null;
            Carrinho carrinho = null;
            Item item = null;
            
            context["Dado que um cliente em compras no site"] = () =>
            {
                cliente = new Cliente();
                carrinho = new Carrinho(cliente);
                
                context["adiciona um item de R$ 100,00 no carrinho"] = () =>
                {
                    item = new Item(100);
                    carrinho.AdicionarItem(item);
                    
                    it["o total do carrinho será R$ 100,00"] = () =>
                        Assert.Equal(100, carrinho.CalcularTotalItens());
                };
            };
        }
    }
}