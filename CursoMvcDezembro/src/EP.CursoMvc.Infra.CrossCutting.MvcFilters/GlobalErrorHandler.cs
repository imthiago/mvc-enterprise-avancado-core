using Microsoft.AspNetCore.Mvc.Filters;

namespace EP.CursoMvc.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // throw
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                // Tratar o erro de alguma forma
                // 1 - Gravar no EventViewer
                // 2 - Gravar no banco
                // 3 - Enviar um e-mail
                // 4 - Fazer tudo isso e mais alguma coisa
            }
        }
    }
}