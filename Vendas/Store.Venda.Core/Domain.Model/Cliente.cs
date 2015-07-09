using System;
using System.Linq;
using System.Collections.Generic;
using Store.Common.Domain.Model;
using Store.Venda.Core.Domain.Model.Specs;

namespace Store.Venda.Core.Domain.Model
{
    public class Cliente : Entity
    {
        public ICollection<Endereco> Enderecos { get; private set; }

        public Cliente() : base(Guid.NewGuid())
        {
            this.Enderecos = new List<Endereco>();
        }

        internal void AdicionarNovoEnderecoDeEntrega(Endereco endereco)
        {
            this.Enderecos.Add(endereco);
            MarcarEnderecoComoEntrega(endereco.Id);
        }

        internal void MarcarEnderecoComoEntrega(Guid id)
        {
            this.Enderecos
                .Where(x => x.Id != id).ToList()
                .ForEach(x => { x.DesmarcarEnderecoDeEntrega(); });
            
            this.Enderecos
                .FirstOrDefault(x => x.Id == id)
                .MarcarComoEnderecoDeEntrega();                
        }
        
        internal Endereco RecuperarEnderecoEntrega()
        {
            return this.Enderecos.AsQueryable().FirstOrDefault(ClienteSpec.EnderecoDeEntrega());
        }
    }
}