﻿using FluentValidation;
using Mttechne.Backend.Junior.Domain.Entidades;
using Mttechne.Backend.Junior.Services.Interfaces;
using Mttechne.Backend.Junior.Services.Notificacoes;
using System.ComponentModel.DataAnnotations;

namespace Mttechne.Backend.Junior.Services.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
                Notificar(validationResult.ErrorMessage);            
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            foreach (var error in validator.Errors)
            {
                Notificar(error.ErrorMessage);
            }

            return false;
        }
    }
}
