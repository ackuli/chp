using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HMS.Admin.Startup))]
namespace HMS.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
