using Sinaf.Teste.Domain.Notification;
using System;
using System.Collections.Generic;

namespace Sinaf.Teste.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Char Sexo { get; private set; }
        public string Email { get; private set; }
        public ICollection<Endereco> Enderecos  { get; private set; }
        public ICollection<Telefone> Telefones { get; private set; }

        public Cliente()
        {
            this.Enderecos = new List<Endereco>();
            this.Telefones = new List<Telefone>();
            this.Notifications = new NotificationContext();
        }

        public void ValidarInclusao()
        {
            if (string.IsNullOrWhiteSpace(this.Nome))            
                this.Notifications.AddNotification("Informe o nome do cliente");

            if (string.IsNullOrWhiteSpace(this.Cpf))
                this.Notifications.AddNotification("Informe o CPF do cliente");

            if (this.DataNascimento == DateTime.MinValue)
                this.Notifications.AddNotification("Informe a data de nascimento do cliente");

            if (this.Sexo != 'm' && this.Sexo != 'M' && this.Sexo != 'f' && this.Sexo != 'F')
                this.Notifications.AddNotification("Informe o sexo (M ou F)");

            if (string.IsNullOrWhiteSpace(this.Email))
                this.Notifications.AddNotification("Informe o e-mail do cliente");
        }
    }
}
