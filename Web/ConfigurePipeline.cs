using System.Reflection.Metadata.Ecma335;

namespace Web
{
    public static class ConfigurePipeline
    {
        public static WebApplication ConfigurePipelines(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
           
            app.UseSwagger();
            app.UseSwaggerUI( setupAction => 
            {
                setupAction.SwaggerEndpoint("/swagger/HospitalAPI/swagger.json", "Hospital API");
                setupAction.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            return app; 
        }
    }
}
