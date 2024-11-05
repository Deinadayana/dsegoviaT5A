using dsegoviaS5A.Utils;
using Microsoft.Extensions.Logging;

namespace dsegoviaS5A
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = FileAccessHelper.GetLocalFilePath("personas.db");
            builder.Services.AddSingleton<PersonRepository>(s => new PersonRepository(dbPath));

            builder.Logging.AddDebug();

            return builder.Build();
        }
    }
}
