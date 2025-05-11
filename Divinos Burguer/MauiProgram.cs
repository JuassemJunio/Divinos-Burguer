using CommunityToolkit.Maui;
using Divinos_Burguer.ViewModel;
using Divinos_Burguer.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Auth.Google;
using Plugin.Firebase.Firestore;
using Plugin.Firebase.Storage;

#if IOS
using Plugin.Firebase.Core.Platforms.iOS;
#elif ANDROID
using Plugin.Firebase.Core.Platforms.Android;
#endif

namespace Divinos_Burguer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .RegisterFirebaseServices()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //Views
            builder.Services.AddSingleton<LoginPage>();

            //ViewModels
            builder.Services.AddSingleton<LoginPageViewModel>();

            builder.Services.AddSingleton(_ => CrossFirebaseFirestore.Current);
            builder.Services.AddSingleton(_ => CrossFirebaseStorage.Current);

            builder.Services.AddSingleton<IUserService, UserService>();

            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events => {
#if IOS
    events.AddiOS(iOS => iOS.WillFinishLaunching((_, __) => {
        CrossFirebase.Initialize();
        FirebaseAuthGoogleImplementation.Initialize();
        return false;
    }));
#elif ANDROID
                events.AddAndroid(android => android.OnCreate((activity, _) => {
                    CrossFirebase.Initialize(activity);
                    FirebaseAuthGoogleImplementation.Initialize("1087786763726-26d852i83gfiirknbg5vosa24lf6vbsl.apps.googleusercontent.com");
                }));
#endif
            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            return builder;
        }

    }
}
