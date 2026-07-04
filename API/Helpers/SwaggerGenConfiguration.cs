using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Helpers
{
    public class SwaggerGenConfiguration : IConfigureNamedOptions<SwaggerGenOptions>
    {

        #region Fields

        private readonly IApiVersionDescriptionProvider _provider;
        private readonly ILogger<SwaggerGenConfiguration> _logger;

        #endregion


        #region Constructor

        public SwaggerGenConfiguration(IApiVersionDescriptionProvider provider, ILogger<SwaggerGenConfiguration> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        #endregion


        #region Methods

        public void Configure(string? _, SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = $"API v{description.ApiVersion}",
                    Version = description.ApiVersion.ToString("0.0"),
                };

                try
                {
                    options.SwaggerDoc(description.GroupName, openApiInfo);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error in {nameof(SwaggerGenConfiguration)}");
                }
            }
        }

        public void Configure(SwaggerGenOptions options)
        {
            Configure(options);
        }

        #endregion

    }
}
