using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace SRPIntranet.IntegrationTest
{
    [TestClass]
    public class AuthorizationTest
    {

        [TestMethod]
        public void Connect_Challenge()
        {
            var service = new SrbWebOpenIdConnect("http://localhost:44300", "openid offline_access", "webtest");
            service.Connect("pau", "pwd", "/connect/token");

            var resWithLogin = service.TestApi("/api/message", HttpMethod.Get);
            resWithLogin.Should().NotBeNullOrEmpty();

            // challenge on WebApiClient dont work 
            var resOtherApi = service.TestApi("http://localhost:44301/api/message", HttpMethod.Get);
            resOtherApi.Should().NotBeNullOrEmpty();
        }


        [TestMethod]
        public void Connect_Refresh()
        {
            var service = new SrbWebOpenIdConnect("http://localhost:44300", "openid offline_access", "webtest");
            service.Connect("pau", "pwd", "/connect/token");
            service.TokenOpenId.RefreshToken.Should().NotBeNullOrEmpty();

            var roles = service.GetClaim("name");

            var resWithLogin = service.TestApi("/api/message", HttpMethod.Get);
            resWithLogin.Should().NotBeNullOrEmpty();

            service.Refresh("/connect/token", service.TokenOpenId.RefreshToken);
            var resWithRefresh = service.TestApi("/api/message", HttpMethod.Get);
        }
    }
}
