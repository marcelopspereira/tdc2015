using Xunit;
using System;
using System.Linq;
using BetterSpecs;
using Store.Venda.Core.Domain.Model;

namespace Store.Venda.Tests
{
    public class CarrinhoTestes : SpecContext
    {
        private Carrinho carrinho;

        [Fact]
        public void adicionando_e_removendo_itens_no_carrinho()
        {
            carrinho = new Carrinho(Guid.Empty);
            Console.WriteLine();

            context["Dado que um cliente em compras no site"] = () =>
            {
                context["adiciona um produto de R$ 100,00 no carrinho"] = () =>
                {
                    carrinho.AdicionarProduto(new Produto(100));
                    it["o total do carrinho é R$ 100,00"] = () => Assert.Equal(100, carrinho.Calcular());
                };

                context["adiciona um produto de R$ 400,00 "] = () =>
                {
                    carrinho.AdicionarProduto(new Produto(400));
                    it["o total do carrinho é R$ 500,00"] = () => Assert.Equal(500, carrinho.Calcular());
                };

                context["remove o ultimo item"] = () =>
                {
                    carrinho.RemoverItem(carrinho.UltimoItemLancado);
                    it["o total do carrinho é R$ 100,00"] = () => Assert.Equal(100, carrinho.Calcular());
                };
            };

            Console.WriteLine();
        }

        [Fact]
        public void alterar_quantidade_de_item_de_um_carrinho()
        {
            carrinho = new Carrinho(Guid.Empty);

            context["Dado um carrinho com um produto de R$ 100,00"] = () =>
            {
                carrinho.AdicionarProduto(new Produto(100));

                context["Ao incrementar este produto com mais 1 unidade"] = () =>
                {
                    carrinho.AumentarQuantidadeItem(carrinho.UltimoItemLancado, 1);
                    
                    it["a quantidade final será 2"] = () => Assert.Equal(2, carrinho.Itens.Last().Quantidade);
                    it["o subtotal será R$ 200,00"] = () => Assert.Equal(200, carrinho.Calcular());
                };
                
                context["Ao decrementar este produto com menos 1 unidade"] = () =>
                {
                    carrinho.DiminuirQuantidadeItem(carrinho.UltimoItemLancado, 1);
                    
                    it["a quantidade final será 1"] = () => Assert.Equal(1, carrinho.Itens.Last().Quantidade);
                    it["o subtotal será R$ 100,00"] = () => Assert.Equal(100, carrinho.Calcular());
                };                
            };
            Console.WriteLine();
        }

    }
}