using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignupWithLogin.Startup))]
namespace SignupWithLogin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
