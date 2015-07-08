using System;
using Store.Common.Domain.Model;

namespace Store.Venda.Core.Domain.Model
{
    public class Cliente : Entity
    {
        public Cliente() : base(Guid.NewGuid())
        {
        }
    }
}