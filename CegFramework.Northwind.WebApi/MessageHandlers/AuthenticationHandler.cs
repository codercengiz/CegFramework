using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CegFramework.Northwind.Business.Abstract;
using CegFramework.Northwind.Business.DependencyResolvers.Ninject;
using CegFramework.Northwind.Entities.Concrete;

namespace CegFramework.Northwind.WebApi.MessageHandlers
{
    public class AuthenticationHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {

                    byte[] data = Convert.FromBase64String(token);
                    string decodingString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodingString.Split(':');

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();
                    User user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user!=null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]),
                            userService.GetUserRoles(user).Select(x=> x.RoleName).ToArray() );
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}