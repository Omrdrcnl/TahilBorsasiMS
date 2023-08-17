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
                    new HttpContextAccessor().HttpContext.Session.SetString("UserName", value ?? "");
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
                    new HttpContextAccessor().HttpContext.Session.SetString("Token", value ?? "");
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
                    new HttpContextAccessor().HttpContext.Session.SetString("Rol", value ?? "");
                }
            }
            public static string? Name
            {
                get
                {
                    string name = new HttpContextAccessor().HttpContext.Session.GetString("Name");
                    return name;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("Name", value ?? "");
                }
            }
            public static string? Mail
            {
                get
                {
                    string mail = new HttpContextAccessor().HttpContext.Session.GetString("Mail");
                    return mail;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("Mail", value ?? "");
                }
            }
            public static string? Message
            {
                get
                {
                    string message = new HttpContextAccessor().HttpContext.Session.GetString("Message");
                    return message;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("Message", value ?? "");
                }
            }
            public static string? Subject
            {
                get
                {
                    string subject = new HttpContextAccessor().HttpContext.Session.GetString("Subject");
                    return subject;
                }
                set
                {
                    new HttpContextAccessor().HttpContext.Session.SetString("Subject", value ?? "");
                }
            }
        }
    }
}
