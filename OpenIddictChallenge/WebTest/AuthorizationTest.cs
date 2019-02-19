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
            var service = new SrbWebOpenIdConnect("http://localhost:44300");
            service.Connect("pau", "pwd", "/connect/token");
            service.TokenOpenId.RefreshToken.Should().NotBeNullOrEmpty();
            var functions = service.GetClaim("functions");
            var roles = service.GetClaim("role");

            var resWithLogin = service.TestUrl("/api/ClientMenu", HttpMethod.Get);
            resWithLogin.Should().NotBeNullOrEmpty();

            service.Refresh("/connect/token", service.TokenOpenId.RefreshToken);
            var resWithRefresh = service.TestUrl("/api/ClientMenu", HttpMethod.Get);

            var test = service.TestUrl("http://localhost:44302/api/PlanningRetours", HttpMethod.Get);
        }
    }
}
