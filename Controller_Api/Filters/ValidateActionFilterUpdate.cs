using ApiBanco.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Controller_Api.Filters
{
    public class ValidateActionFilterUpdate : ActionFilterAttribute
    {
        public ICadastroService _cadastroService;
        public ValidateActionFilterUpdate(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            string cpf = (string)context.ActionArguments["cpf"];
            if (_cadastroService.ConsultarCadastroCliente(cpf) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
            else if (_cadastroService.ConsultarCadastroCliente(cpf) != null 
                    && HttpMethods.IsPut(context.HttpContext.Request.Method))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
