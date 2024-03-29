﻿using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Quarantaine_APP.Interfaces;
using Quarantaine_APP.Services;
using Quarantaine_APP.ViewModels;
using Quarantaine_APP.Views;

namespace Quarantaine_APP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<INotifyService, NotificationService>();
            builder.Services.AddSingleton<IParse, RSSParser>();
            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<ILocation, GeoLocationService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<TestResultPage>();
            builder.Services.AddSingleton<TestResultViewModel>();
            return builder.Build();
        }
    }
}
