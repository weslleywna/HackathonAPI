﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Hackathon_API.ViewModels;

namespace Hackathon_API.FluentValidation
{
    public class CandidatoValidator : AbstractValidator<CandidatoViewModel>
    {
        public CandidatoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentNullException("Não foi possível encontrar o objeto."); });

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .Matches(@"^[a-zA-z\u00C0-\u00FF\s]{1,40}$")
                .WithMessage("O nome não pode conter número e/ou caracteres especiais")
                .Must(c => !c.Contains("  ")).WithMessage("O nome não pode conter dois espaços seguidos")
                .Must(c => !c.StartsWith(' ')).WithMessage("O nome não pode começar com espaço");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O nome da cidade é obrigatório")
                .Matches(@"^[a-zA-z\u00C0-\u00FF\s]{1,40}$")
                .WithMessage("O nome da cidade não pode conter número e/ou caracteres especiais")
                .Must(c => !c.Contains("  ")).WithMessage("O nome não pode conter dois espaços seguidos")
                .Must(c => !c.StartsWith(' ')).WithMessage("O nome da cidade não pode começar com espaço");

            RuleFor(c => c.Nota)
                .LessThanOrEqualTo(100).WithMessage("A nota não pode ser maior que 100")
                .GreaterThanOrEqualTo(0).WithMessage("A nota não pode ser menor que 0");
        }
    }
}
