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
            
            context["Dado que um cliente em compras no site"] = () =>
            {
                cliente = new Cliente();
                carrinho = new Carrinho(cliente);
                
                context["adiciona um item de R$ 100,00 no carrinho"] = () =>
                {
                    carrinho.AdicionarItem(new Item(100));
                    
                    it["o total do carrinho será R$ 100,00"] = () =>
                        Assert.Equal(100, carrinho.CalcularTotalItens());
                };

                context["adiciona outro item de R$ 100,00 "] = () =>
                {
                    carrinho.AdicionarItem(new Item(100));
                    
                    it["o total do carrinho agora será R$ 200,00"] = () =>
                        Assert.Equal(200, carrinho.CalcularTotalItens());
                };
            };
        }
    }
}