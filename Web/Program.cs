
namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = WebApplication.CreateBuilder(args)
                .BuildServices()
                .ConfigurePipelines();
            //Microsoft.DocAsCode.Docset.Build("docfx.json");
            //Microsoft.DocAsCode.Docset.Build("docfx.json");

            app.Run();
        }
    }
}