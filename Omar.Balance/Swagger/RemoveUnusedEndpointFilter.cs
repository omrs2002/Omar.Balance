using AutoMapper.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Omar.Balance.Swagger
{
    internal class RemoveUnusedEndpointFilter : IDocumentFilter
    {
        public RemoveUnusedEndpointFilter()
        {
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {

            foreach (var apiDescription in context.ApiDescriptions)
            {
                if (apiDescription.RelativePath == null) continue;

                if (apiDescription.RelativePath.Contains("/abp/") ||
                    apiDescription.RelativePath.Contains("api/identity") ||
                    apiDescription.RelativePath.Contains("api/account") ||
                    apiDescription.RelativePath.Contains("api/permission-management") ||
                    apiDescription.RelativePath.Contains("api/multi-tenancy") ||
                    apiDescription.RelativePath.Contains("api/feature-management") ||
                    apiDescription.RelativePath.Contains("api/setting-management")
                    )
                {
                    var keyToRemove = swaggerDoc.Paths
                        .FirstOrDefault(p => p.Key.ToLower().Contains(apiDescription.RelativePath.ToLower())).Key;

                    if (keyToRemove != null)
                        swaggerDoc.Paths.Remove(keyToRemove);
                }
            }
        }
    }
}
