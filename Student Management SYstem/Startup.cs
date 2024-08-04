using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Student_Management_SYstem.Startup))]
namespace Student_Management_SYstem
{ 

public partial class Startup
{
    public void Configuration(IAppBuilder app)
    {
        ConfigureAuth(app);
    }
}
}
