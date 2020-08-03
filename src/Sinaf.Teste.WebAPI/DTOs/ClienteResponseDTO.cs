using System;
using System.Collections.Generic;

namespace Sinaf.Teste.WebAPI.DTOs
{
    public class ClienteResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Char Sexo { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Enderecos { get; set; }
        public IEnumerable<string> Telefones { get; set; }
    }
}