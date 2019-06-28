using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstaLearn.Startup))]
namespace InstaLearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
