using System.Web.Http;
using WebActivatorEx;
using SwaggerDemo;
using Swashbuckle.Application;
using System.Web.Routing;
using System.Web.UI;
using System.Reflection;
using System;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
[assembly: WebResource("SwaggerDemo.TethrSwagger.css", "text/css")]

namespace SwaggerDemo
{
    public class SwaggerConfig
    {
        public const string resourceName = "SwaggerDemo.Content.TethrSwagger.css";

        public static void Register()
        {
            GlobalConfiguration.Configuration 
                .EnableSwagger(
                    "help/docs/{apiVersion}",
                    c =>
                    {
                        //c.RootUrl(req => GetRootUrlFromAppConfig());
                        //c.Schemes(new[] { "http", "https" });
                        c.SingleApiVersion("v1", "Tethr APIs")
                            .Description("Demonstrate Swashbuckler");
                        //c.MultipleApiVersions(
                        //    (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                        //    (vc) =>
                        //    {
                        //        vc.Version("v2", "Swashbuckle Dummy API V2");
                        //        vc.Version("v1", "Swashbuckle Dummy API V1");
                        //    });
                        // See https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md
                        //c.BasicAuth("basic").Description("Basic HTTP Authentication");
                        //c.ApiKey("apiKey").Description("API Key Authentication").Name("apiKey").In("header");
                        //c.OAuth2("oauth2").Description("OAuth2 Implicit Grant").Flow("implicit")
                        //    .AuthorizationUrl("http://petstore.swagger.wordnik.com/api/oauth/dialog")
                        //    //.TokenUrl("https://tempuri.org/token")
                        //    .Scopes(scopes =>
                        //    {
                        //        scopes.Add("read", "Read access to protected resources");
                        //        scopes.Add("write", "Write access to protected resources");
                        //    });
                        //c.IgnoreObsoleteActions();
                        //c.GroupActionsBy(apiDesc => apiDesc.HttpMethod.ToString());
                        //c.OrderActionGroupsBy(new DescendingAlphabeticComparer());
                        c.IncludeXmlComments(GetDocumentationPath());
                        //c.MapType<ProductType>(() => new Schema { type = "integer", format = "int32" });
                        //c.SchemaFilter<ApplySchemaVendorExtensions>();
                        //c.UseFullTypeNameInSchemaIds();
                        //c.SchemaId(t => t.FullName.Contains('`') ? t.FullName.Substring(0, t.FullName.IndexOf('`')) : t.FullName);
                        //c.IgnoreObsoleteProperties();
                        //c.DescribeAllEnumsAsStrings();
                        //c.OperationFilter<AddDefaultResponse>();
                        //c.OperationFilter<AssignOAuth2SecurityRequirements>();
                        //c.DocumentFilter<ApplyDocumentVendorExtensions>();
                        //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                        //c.CustomProvider((defaultProvider) => new CachingSwaggerProvider(defaultProvider));
                    })
                .EnableSwaggerUi(
                    "help/ui/{*assetPath}",
                    c =>
                    {
                        c.InjectStylesheet(Assembly.GetExecutingAssembly(), resourceName);
                        //c.InjectJavaScript(thisAssembly, "Swashbuckle.Dummy.SwaggerExtensions.testScript1.js");
                        //c.BooleanValues(new[] { "0", "1" });
                        //c.SetValidatorUrl("http://localhost/validator");
                        //c.DisableValidator();
                        //c.DocExpansion(DocExpansion.List);
                        //c.SupportedSubmitMethods("GET", "HEAD");
                        //c.CustomAsset("index", containingAssembly, "YourWebApiProject.SwaggerExtensions.index.html");
                        //c.EnableDiscoveryUrlSelector();
                        //c.EnableOAuth2Support(clientId: "test-client-id", clientSecret: null, realm: "test-realm", appName: "Swagger UI"
                        //    //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
                        //);
                        //c.EnableApiKeySupport("apiKey", "header");
                    });
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "help_ui_shortcut",
                constraints: new RouteValueDictionary(){ { "uriResolution", new HttpRouteDirectionConstraint(allowedDirection: System.Web.Http.Routing.HttpRouteDirection.UriResolution) } },
                defaults: new RouteValueDictionary(),
                routeTemplate: "help",
                handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, "help/ui/index"));
        }

        private static string GetDocumentationPath()
        {
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            var commentsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", commentsFileName);
            return commentsFile;
        }
    }
}
