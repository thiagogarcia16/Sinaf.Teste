using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinaf.Teste.WebAPI.DTOs
{
    public class ApoliceResponseDTO
    {
        public long Id { get; set; }     
        public ClienteResponseDTO Cliente { get; set; }        
        public CorretorResponseDTO Corretor { get; set; }
        public decimal Premio { get; set; }
        public ICollection<CoberturaResponseDTO> Coberturas { get; set; }
        public ICollection<string> Dependentes { get; set; }
    }
}
