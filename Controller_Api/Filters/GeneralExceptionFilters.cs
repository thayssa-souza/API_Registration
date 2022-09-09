using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace Controller_Api.Filters
{
    public class GeneralExceptionFilters : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails
            {
                Status = 500,
                Title = "Erro inesperado...",
                Detail = "Lamento, ocorreu um erro inesperado na solicitação.",
                Type = context.Exception.GetType().Name
            };

            Console.WriteLine($"Tipo da exceção {context.Exception.GetType().Name}, mensagem {context.Exception.Message}, stack trace {context.Exception.StackTrace}");

            switch(context.Exception)
            {
                case SqlException:
                    problem.Status = 503;
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    Console.WriteLine("Erro inesperado ao se comunicar com o banco de dados. Tente mais tarde.");
                break;
                case NullReferenceException:
                    problem.Status = 417;
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    Console.WriteLine("Erro inesperado no sistema. Tente novamente mais tarde.");
                break;
                default:
                    problem.Status = 500;
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    Console.WriteLine("Erro inesperado. Tente novamente.");
                break;
            }
        }

    }
}
