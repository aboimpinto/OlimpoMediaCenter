using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using OlimpoMediaCenter.AvaloniaUI.DIContainer;
using OlimpoMediaCenter.AvaloniaUI.Extensions;
using OlimpoMediaCenter.AvaloniaUI.ViewModels;

namespace OlimpoMediaCenter.AvaloniaUI.AppBuilders
{
    public static class ServiceLocatorExtensions
    {
        public static T UseViewModels<T>(this T builder, IServiceLocator serviceLocator)  where T : AppBuilderBase<T>, new()
        {
            serviceLocator.ServiceCollection
                .AddScoped<ViewModelBase, MainWindowViewModel>("MainWindowViewModel");

            return builder;
        }
    }
}
