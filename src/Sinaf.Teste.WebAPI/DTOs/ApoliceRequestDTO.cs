using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinaf.Teste.WebAPI.DTOs
{
    public class ApoliceRequestDTO
    {
        public ClienteRequestDTO Cliente { get; set; }
        public IEnumerable<CoberturaRequestDTO> Coberturas { get; set; }
        public IEnumerable<string> Dependentes { get; set; }
        public string Corretor { get; set; }
    }
}
