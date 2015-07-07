using Xunit;
using System;
using System.Linq;
using BetterSpecs;
using Store.Venda.Core.Domain.Model;

namespace Store.Venda.Tests
{
    public class CarrinhoTestes : SpecContext
    {
        [Fact]
        public void adicionando_e_removendo_itens_no_carrinho()
        {
            var carrinho = new Carrinho(new Cliente());

            Console.WriteLine();
            
            context["Dado que um cliente em compras no site"] = () =>
            {
                context["adiciona um item de R$ 100,00 no carrinho"] = () =>
                {
                    carrinho.AdicionarItem(new Item(100));
                    it["o total do carrinho é R$ 100,00"] = () => Assert.Equal(100, carrinho.Calcular());
                };

                context["adiciona um item de R$ 400,00 "] = () =>
                {
                    carrinho.AdicionarItem(new Item(100));
                    it["o total do carrinho é R$ 500,00"] = () => Assert.Equal(200, carrinho.Calcular());
                };

                context["remove o ultimo item"] = () =>
                {
                    carrinho.RemoverItem(carrinho.UltimoItemLancado);
                    it["o total do carrinho é R$ 100,00"] = () => Assert.Equal(100, carrinho.Calcular());
                };
            };
            
            Console.WriteLine();
        }
    }
}