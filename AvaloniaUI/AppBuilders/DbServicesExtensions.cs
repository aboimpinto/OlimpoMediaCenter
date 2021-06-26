using Avalonia.Controls;
using AvaloniaUI.DbServices;
using Microsoft.Extensions.DependencyInjection;
// using OlimpoMediaCenter.AvaloniaUI.DbServices;
using OlimpoMediaCenter.AvaloniaUI.DIContainer;

namespace OlimpoMediaCenter.AvaloniaUI.AppBuilders
{
    public static class DbServicesExtensions
    {
        public static T UseDbServices<T>(this T builder, IServiceLocator serviceLocator)  where T : AppBuilderBase<T>, new()
        {
            // serviceLocator.ServiceCollection
            //     .AddSingleton<IChannelsService, ChannelsService>();

            serviceLocator.ServiceCollection
                .AddSingleton<IChannelsContext, ChannelsContext>();

            return builder;
        }
    }
}
