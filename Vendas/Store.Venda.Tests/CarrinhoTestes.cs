using Xunit;
using System;
using System.Linq;
using BetterSpecs;
using Fact.Factory;
using Store.Venda.Core.Domain.Model;

namespace Store.Venda.Tests
{
    public class CarrinhoTestes : SpecContext
    {
        private Carrinho carrinho;
        private Produto produto100;
        private Produto produto400;
        
        public CarrinhoTestes()
        {
            VendasFactory.Build();
            
            carrinho = Builder.Current.Build<Carrinho>();
            produto100 = Builder.Current.Build<Produto>("100");
            produto400 = Builder.Current.Build<Produto>("400");
            
        }
        
        public void Dispose()
        {
            Builder.Current.Clear();
        }

        [Fact]
        public void adicionando_e_removendo_itens_no_carrinho()
        {
            describe["Dado que um cliente em compras no site"] = () =>
            {
                context["adiciona um produto de R$ 100,00 no carrinho"] = () =>
                {
                    carrinho.AdicionarProduto(produto100);
                    
                    it["o total do carrinho é R$ 100,00"] = () => Assert.Equal(100, carrinho.Calcular());
                };

                context["adiciona um produto de R$ 400,00 "] = () =>
                {
                    carrinho.AdicionarProduto(produto400);
                    
                    it["o total do carrinho é R$ 500,00"] = () => Assert.Equal(500, carrinho.Calcular());
                };

                context["remove o ultimo item"] = () =>
                {
                    carrinho.RemoverItem(carrinho.UltimoItemLancado);
                    
                    it["o total do carrinho é R$ 100,00"] = () => Assert.Equal(100, carrinho.Calcular());
                };
            };
        }

        [Fact]
        public void alterar_quantidade_de_item_de_um_carrinho()
        {
            carrinho = new Carrinho(Guid.NewGuid());

            describe["Dado um carrinho com um produto de R$ 100,00"] = () =>
            {
                carrinho.AdicionarProduto(produto100);

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
        }
    }
}