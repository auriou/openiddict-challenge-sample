using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace SRPIntranet.IntegrationTest
{
    [TestClass]
    public class AuthorizationTest
    {

        [TestMethod]
        public void Connect_Refresh()
        {
            var service = new SrbWebOpenIdConnect("http://localhost:44300", "openid offline_access");
            service.Connect("pau", "pwd", "/connect/token");
            service.TokenOpenId.RefreshToken.Should().NotBeNullOrEmpty();
            
            var roles = service.GetClaim("role");

            var resWithLogin = service.TestApi("/api/message", HttpMethod.Get);
            resWithLogin.Should().NotBeNullOrEmpty();

            //service.Refresh("/connect/token", service.TokenOpenId.RefreshToken);
            //var resWithRefresh = service.TestUrl("/api/ClientMenu", HttpMethod.Get);

            // challenge on WebApiClient
            var test = service.TestApi("http://localhost:44301/api/message", HttpMethod.Get);
        }
    }
}
