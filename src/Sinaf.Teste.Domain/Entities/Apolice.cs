using Sinaf.Teste.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinaf.Teste.Domain.Entities
{
    public class Apolice : EntityBase
    {
        public long ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public long CorretorId { get; private set; }
        public Corretor Corretor { get; private set; }
        public decimal Premio { get; private set; }
        public ICollection<Cobertura> Coberturas { get; private set; }
        public ICollection<Dependente> Dependentes { get; private set; }

     

        public Apolice()
        {
            this.Coberturas = new List<Cobertura>();
            this.Dependentes = new List<Dependente>();
            this.Notifications = new NotificationContext();
        }

        public void CalcularPremio()
        {
            this.Premio = 0;

            foreach (var cobertura in this.Coberturas)            
                this.Premio += cobertura.CalcularPremio();            
        }

        public void ValidarInclusao()
        {
            if (!this.Coberturas.Any())
            {
                this.Notifications.AddNotification("Informe a cobertura");
                return;
            }

            if (!this.Coberturas.Any(a => !a.Nome.Equals(Cobertura.CoberturaObrigatoria, StringComparison.OrdinalIgnoreCase)))
            {
                this.Notifications.AddNotification("É necessário incluir outra cobertura além de Assistência Funeral");
                return;
            }

            if (!this.Coberturas.Any(a => a.Nome.Equals(Cobertura.CoberturaObrigatoria, StringComparison.OrdinalIgnoreCase)))
                this.Notifications.AddNotification("É obrigatório incluir a cobertura de Assistência Funeral");
        }
    }
}
