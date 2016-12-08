using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MealDesignerPRO.Startup))]
namespace MealDesignerPRO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
