using System;

namespace Store.Common.Domain.Model
{
    public class Endereco : ValueObject
    {
        public Guid Id { get; private set; }
        public string Lougradouro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }
        public bool EnderecoEntrega { get; private set; }

        public Endereco(string cep, string lougradouro, string cidade, string uf)
        {
            this.Id = Guid.NewGuid();
            this.Lougradouro = lougradouro;
            this.Cidade = cidade;
            this.UF = uf;
        }

        public void MarcarComoEnderecoDeEntrega()
        {
            this.EnderecoEntrega = true;
        }

        public void DesmarcarEnderecoDeEntrega()
        {
            this.EnderecoEntrega = false;
        }
    }
}