using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Omar.Balance.Swagger
{
    public class RemoveUnusedSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            //string[] excludedSchemas = { "ApplicationConfigurations", "ControllerInterfaceApiDescriptionModel", "MethodParameterApiDescriptionModel", "ParameterApiDescriptionModel", "ReturnValueApiDescriptionModel", "ActionApiDescriptionModel", "ControllerApiDescriptionModel", "ModuleApiDescriptionModel", "PropertyApiDescriptionModel", "TypeApiDescriptionModel", "ApplicationApiDescriptionModel", "LanguageInfo", "DateTimeFormatDto", "CurrentCultureDto", "ApplicationLocalizationConfigurationDto", "ApplicationAuthConfigurationDto", "ApplicationSettingConfigurationDto", "CurrentUserDto", "ApplicationFeatureConfigurationDto", "MultiTenancyInfoDto", "CurrentTenantDto", "IanaTimeZone", "WindowsTimeZone", "TimeZone", "TimingDto", "ClockDto", "LocalizableStringDto", "ExtensionPropertyApiGetDto", "ExtensionPropertyApiCreateDto", "ExtensionPropertyApiUpdateDto", "ExtensionPropertyApiDto", "ExtensionPropertyUiTableDto", "ExtensionPropertyUiFormDto", "ExtensionPropertyUiDto", "ExtensionPropertyAttributeDto", "ExtensionPropertyDto", "EntityExtensionDto", "ModuleExtensionDto", "ExtensionEnumFieldDto", "ExtensionEnumDto", "ObjectExtensionsDto", "ApplicationConfigurationDto" };
            string[] IncludedSchemas = { "RemoteServiceErrorResponse", "RemoteServiceErrorInfo", "RemoteServiceValidationErrorInfo" };

            foreach (var item in
                context.SchemaRepository
                .Schemas
                .Keys
                .Where(ex => !IncludedSchemas.Contains(ex)))
                context.SchemaRepository.Schemas.Remove(item);
        }

    }

}
