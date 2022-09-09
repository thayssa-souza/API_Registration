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
        }
    }
}
