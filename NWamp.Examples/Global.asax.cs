using System;
using System.Net;

namespace NWamp.Examples
{
    public class Global : System.Web.HttpApplication
    {
        private BaseWampHost _host;

        protected void Application_Start(object sender, EventArgs e)
        {
            _host = new AlchemyWampHost(IPAddress.Any, 3333)
                .RegisterFunction("http://localhost:3333/Calculator#Add", (double x, double y) => x + y)
                .RegisterFunction("http://localhost:3333/Calculator#Sub", (double x, double y) => x - y)
                .RegisterFunction("http://localhost:3333/Calculator#Mul", (double x, double y) => x * y)
                .RegisterFunction("http://localhost:3333/Calculator#Div", (double x, double y) => x / y);

            _host.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            if(_host!= null)
            {
                _host.Dispose();
                _host = null;
            }
        }
    }
}