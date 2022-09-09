using ApiBanco.Core.Interfaces;
using ApiBanco.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Controller_Api.Filters
{
    public class ValidateActionFilterByCpf : ActionFilterAttribute
    {
        public ICadastroService _cadastroService;
        public ValidateActionFilterByCpf(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            string cpf = (string)context.ActionArguments["cpf"];
            if(_cadastroService.ConsultarCadastroCliente(cpf) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            else if(_cadastroService.Equals(cpf))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            else
            {
                context.Result = new StatusCodeResult(StatusCodes.Status201Created);
            }
        }
    }
}
