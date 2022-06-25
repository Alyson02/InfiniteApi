using FluentValidation;
using Infinite.Core.Business.CQRS.Cupom.Commands;
using Infinite.Core.Business.Services.Base;
using Infinite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinite.Core.Business.CQRS.Cupom.Validations
{
    internal class UpdateCupomValidator : AbstractValidator<UpdateCupomCommand>
    {
        public UpdateCupomValidator(IServiceBase<CupomEntity> service)
        {
            RuleFor(x => x.TipoCupomId)
                .Custom((TipoCupom, contexto) =>
                {
                    var spec = service.CreateSpec(x => x.TipoCupomId == TipoCupom)
                        .AddInclude(x => x.TipoCupom);
                    var temTipoCupom = service.FindAsync(spec).Result;

                    if (temTipoCupom == null)
                    {
                        contexto.AddFailure("ID de Tipo de cupom não cadastrado");
                    }
                });
        }

    }
}
