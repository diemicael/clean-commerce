using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanCommerce.API.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FluentValidation.ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            var result = new ObjectResult(new { errors = errors })
            {
                StatusCode = 400, // Bad Request
            };
            
            context.Result = result;
            context.ExceptionHandled = true;
        }
        else if (context.Exception is InvalidOperationException invalidOperationException)
        {
            // Tratar erro 404 (Não encontrado)
            context.Result = new ObjectResult(new { Error = invalidOperationException.Message })
            {
                StatusCode = StatusCodes.Status404NotFound
            };
            context.ExceptionHandled = true;
        }
        else if (context.Exception is HttpRequestException || context.Exception is InvalidOperationException)
        {
            // Tratar erro 500 (Erro interno do Servidor)
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            context.ExceptionHandled = true;
        }
    }
}