using EmbeddedMvc.IdentityServer;
using IdentityServer3.Core;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using PRIS.IdentityServer.IdentityServer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(PRIS.IdentityServer.Startup))]

namespace PRIS.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // todo: replace with serilog
            //LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.Map("/identity", idsrvApp =>
                {
                    var factory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get());

                    var viewOptions = new DefaultViewServiceOptions();
                    viewOptions.Stylesheets.Add("~/Content/Site.css");
                    viewOptions.Stylesheets.Add("~/Content/animation-style_css");

                    viewOptions.CacheViews = false;
                    factory.ConfigureDefaultViewService(viewOptions);

                    var options = new IdentityServerOptions
                    {
                        SiteName = "PRIS",

                        SigningCertificate = LoadCertificate(),
                        Factory = factory,
                        RequireSsl = false,

                        AuthenticationOptions = new AuthenticationOptions
                        {
                            IdentityProviders = ConfigureAdditionalIdentityProviders,
                        }
                    };

                    idsrvApp.UseIdentityServer(options);
                });

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            #region openIdConnect
            //app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            //{
            //    Authority = "https://localhost:44319/identity",

            //    ClientId = "mvc",
            //    Scope = "openid profile roles sampleApi",
            //    ResponseType = "id_token token",
            //    RedirectUri = "https://localhost:44319/",

            //    SignInAsAuthenticationType = "Cookies",
            //    UseTokenLifetime = false,

            //    Notifications = new OpenIdConnectAuthenticationNotifications
            //    {
            //        SecurityTokenValidated = async n =>
            //            {
            //                var nid = new ClaimsIdentity(
            //                    n.AuthenticationTicket.Identity.AuthenticationType,
            //                    Constants.ClaimTypes.GivenName,
            //                    Constants.ClaimTypes.Role);

            //                    // get userinfo data
            //                    var userInfoClient = new UserInfoClient(
            //                    new Uri(n.Options.Authority + "/connect/userinfo"),
            //                    n.ProtocolMessage.AccessToken);

            //                var userInfo = await userInfoClient.GetAsync();
            //                userInfo.Claims.ToList().ForEach(ui => nid.AddClaim(new Claim(ui.Item1, ui.Item2)));

            //                    // keep the id_token for logout
            //                    nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

            //                    // add access token for sample API
            //                    nid.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

            //                    // keep track of access token expiration
            //                    nid.AddClaim(new Claim("expires_at", DateTimeOffset.Now.AddSeconds(int.Parse(n.ProtocolMessage.ExpiresIn)).ToString()));

            //                    // add some other app specific claim
            //                    nid.AddClaim(new Claim("app_specific", "some data"));

            //                n.AuthenticationTicket = new AuthenticationTicket(
            //                    nid,
            //                    n.AuthenticationTicket.Properties);
            //            },

            //        RedirectToIdentityProvider = n =>
            //            {
            //                if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
            //                {
            //                    var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

            //                    if (idTokenHint != null)
            //                    {
            //                        n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
            //                    }
            //                }

            //                return Task.FromResult(0);
            //            }
            //    }
            //});
            #endregion
        }

        public static void ConfigureAdditionalIdentityProviders(IAppBuilder app, string signInAsType)
        {
            var google = new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                SignInAsAuthenticationType = signInAsType,
                ClientId = "767400843187-8boio83mb57ruogr9af9ut09fkg56b27.apps.googleusercontent.com",
                ClientSecret = "5fWcBT0udKY7_b6E3gEiJlze"
            };
            app.UseGoogleAuthentication(google);

            /*

            var fb = new FacebookAuthenticationOptions
            {
                AuthenticationType = "Facebook",
                SignInAsAuthenticationType = signInAsType,
                AppId = "676607329068058",
                AppSecret = "9d6ab75f921942e61fb43a9b1fc25c63"
            };
            app.UseFacebookAuthentication(fb);

            var twitter = new TwitterAuthenticationOptions
            {
                AuthenticationType = "Twitter",
                SignInAsAuthenticationType = signInAsType,
                ConsumerKey = "N8r8w7PIepwtZZwtH066kMlmq",
                ConsumerSecret = "df15L2x6kNI50E4PYcHS0ImBQlcGIt6huET8gQN41VFpUCwNjM"
            };
            app.UseTwitterAuthentication(twitter);
            */
        }

        private void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                Caption = "Sign-in with Google",
                SignInAsAuthenticationType = signInAsType,

                ClientId = "701386055558-9epl93fgsjfmdn14frqvaq2r9i44qgaa.apps.googleusercontent.com",
                ClientSecret = "3pyawKDWaXwsPuRDL7LtKm_o"
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\identityServer\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}