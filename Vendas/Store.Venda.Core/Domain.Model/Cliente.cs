using System;
using Store.Common.Domain.Model;

namespace Store.Venda.Core.Domain.Model
{
    public class Cliente : Entity
    {
        public Guid Id { get; set; }
        
        public Cliente()
        {
            this.Id = Guid.NewGuid();
        }
    }
}