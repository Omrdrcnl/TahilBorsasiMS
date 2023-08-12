namespace TahilBorsaJqeryAjax.Code
{
    public class Repo
    {
        public static class Session
        {

            public static string? UserName
            {
                get
                {
                    string userName = new HttpContextAccessor().HttpContext.Session.GetString("UserName");
                    return userName;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("UserName", value);
                }
            }
            public static string? Token
            {
                get
                {
                    string token = new HttpContextAccessor().HttpContext.Session.GetString("Token");
                    return token;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("Token", value);
                }
            }
            public static string? Rol
            {
                get
                {
                    string rol = new HttpContextAccessor().HttpContext.Session.GetString("Rol");
                    return rol;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("Rol", value);
                }
            }
        }
    }
}
