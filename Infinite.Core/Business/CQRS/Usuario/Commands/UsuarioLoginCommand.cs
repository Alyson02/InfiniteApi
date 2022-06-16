using Infinite.Core.Business.Services.Base;
using Infinite.Core.Domain.Models;
using Infinite.Core.Domain.Entities;
using Infinite.Core.Infrastructure.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Infinite.Core.Business.Services.Token;

namespace Infinite.Core.Business.CQRS.Usuario.Commands
{

    public class UsuarioLoginCommand : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class UsuarioLoginCommandHandler : IRequestHandler<UsuarioLoginCommand, Response>
        {
            private readonly IServiceBase<UsuarioEntity> _service;
            private readonly ITokenService _tokenService;
            public UsuarioLoginCommandHandler(IServiceBase<UsuarioEntity> service, ITokenService tokenService)
            {
                _service = service;
                _tokenService = tokenService;
            }

            public async Task<Response> Handle(UsuarioLoginCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var spec = _service
                        .CreateSpec(x => x.Email == command.Email && 
                        x.Password == command.Password)
                        .AddInclude(x => x.TipoUsuario);
                    var user = await _service.FindAsync(spec);

                    if (user is null) throw new Exception("Email e/ou senha inválido(s)");

                    var token = _tokenService.GerarToken(user);

                    return new Response(token);
                }
                catch (ValidationException ve)
                {
                    throw new ValidationException(ve.Message);
                }
                catch (Exception e)
                {
                    throw new AppException("Erro ao fazer login", e);
                }
            }
        }
    }
}
