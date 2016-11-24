using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aroma_Restaurent.Startup))]
namespace Aroma_Restaurent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
