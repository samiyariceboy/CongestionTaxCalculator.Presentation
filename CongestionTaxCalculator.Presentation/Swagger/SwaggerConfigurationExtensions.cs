using CongestionTaxCalculator.Domain.Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace CongestionTaxCalculator.Application.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void RegisterCustomSwagger(this IServiceCollection services, IConfiguration config)
        {
            var siteUrl = config.GetValue<string>("servicesHostDomainSetting:SiteDomin") ?? "";

            Assert.NotNull(services, nameof(services));

            #region AddSwaggerExamples
            var mainAssembly = Assembly.GetEntryAssembly(); // => MyApi project assembly
            var mainType = mainAssembly.GetExportedTypes()[0];

            var methodName = nameof(Swashbuckle.AspNetCore.Filters.ServiceCollectionExtensions.AddSwaggerExamplesFromAssemblyOf);
            MethodInfo method = typeof(Swashbuckle.AspNetCore.Filters.ServiceCollectionExtensions)
               .GetMethods()
               .Where(C => C.Name.Equals(methodName))
               .FirstOrDefault(x => x.IsGenericMethod);

            MethodInfo generic = method.MakeGenericMethod(mainType);
            generic.Invoke(null, new[] { services });
            #endregion

            services.AddSwaggerGen(option =>
            {
                var XmlDocumentPath = Path.Combine(AppContext.BaseDirectory, "CongestionTaxCalculatorServer.xml");
                option.IncludeXmlComments(XmlDocumentPath, true);
                option.EnableAnnotations();
                option.DescribeAllParametersInCamelCase();



                option.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "CongestionTaxCalculatorServer API V1", Description = "CongestionTaxCalculatorServer v1", Contact = new OpenApiContact() { Email = "samiyariceboy@gmail.com", Name = "samiyar" } });
                option.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "CongestionTaxCalculatorServer API V2", Description = "CongestionTaxCalculatorServer v2", Contact = new OpenApiContact() { Email = "samiyariceboy@gmail.com", Name = "samiyar" } });

                #region 1). Set Swagger Versioning with Reflection
                option.OperationFilter<RemoveVersionParameters>();

                option.DocumentFilter<SetVersionInPaths>();

                option.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var Version = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attri => attri.Versions);

                    return Version.Any(v => $"v{v}" == docName);
                });

                #endregion

                #region 4).Filters summery of action that is not already set (dynamic) pashm rizooon
                option.OperationFilter<ApplySummariesOperationFilter>();
                option.ExampleFilters();

                #endregion

                #region Add UnAuthorized to Response
                //option.OperationFilter<UnauthorizedResponsesOperationFilter>(true, "OAuth2");
                #endregion

                #region 0). Add unAuthorize to Response (importent part)
                //option.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        Password = new OpenApiOAuthFlow
                //        {
                //            TokenUrl = new Uri($"{siteUrl}/v1/Auth/GetTokenJustForSwagger") //,
                //        }//,
                //    }
                //});
                #endregion
            });
        }

        public static void UseCustomSwaggerUI(this IApplicationBuilder app)
        {
            Assert.NotNull(app, nameof(app));

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.DocExpansion(DocExpansion.None);

                option.SwaggerEndpoint("/swagger/v1/swagger.json", "CongestionTaxCalculatorService-v1");
                option.SwaggerEndpoint("/swagger/v2/swagger.json", "CongestionTaxCalculatorService-v2");
                option.InjectStylesheet("/swagger-ui/SwaggerDark.css"); //Comment=to Light Mode
            });

            app.UseReDoc(options =>
            {
                options.SpecUrl("/swagger/v1/swagger.json");
                options.SpecUrl("/swagger/v2/swagger.json");

                #region Customizing
                //By default, the ReDoc UI will be exposed at "/api-docs"
                //options.RoutePrefix = "docs";
                //options.DocumentTitle = "My API Docs";

                options.EnableUntrustedSpec();
                options.ScrollYOffset(10);
                options.HideHostname();
                options.HideDownloadButton();
                options.ExpandResponses("200,201");
                options.RequiredPropsFirst();
                options.NoAutoAuth();
                options.PathInMiddlePanel();
                options.HideLoading();
                options.NativeScrollbars();
                options.DisableSearch();
                options.OnlyRequiredInSamples();
                options.SortPropsAlphabetically();
                #endregion
            });
        }
    }
}
