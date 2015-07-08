using System;
using System.Collections.Generic;
using Store.Common.Domain.Model;

namespace Store.Venda.Core.Domain.Model
{
    public class Cliente : Entity
    {
        public ICollection<Endereco> Enderecos { get; private set; }
        
        public Cliente() : base(Guid.NewGuid())
        {
            this.Enderecos = new List<Endereco>();
        }
        
        internal void AdicionarNovoEndereco(Endereco endereco)
        {
            this.Enderecos.Add(endereco);
        }
    }
}