using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TahilBorsaJqeryAjax.Code.Filters
{
    public class AuthActionFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public string Rol;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!string.IsNullOrEmpty(Rol))
            {
                bool isAuthorized = Rol.Split(',').Contains(Repo.Session.Rol);
                if (!isAuthorized)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else if (string.IsNullOrEmpty(Repo.Session.Rol))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
