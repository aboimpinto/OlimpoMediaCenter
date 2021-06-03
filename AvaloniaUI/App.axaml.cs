using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OlimpoMediaCenter.AvaloniaUI.DIContainer;
using OlimpoMediaCenter.AvaloniaUI.Extensions;
using OlimpoMediaCenter.AvaloniaUI.ViewModels;
using OlimpoMediaCenter.AvaloniaUI.Views;


namespace OlimpoMediaCenter.AvaloniaUI
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = ServiceLocator.Current.ServiceProvider.GetService<ViewModelBase>("MainWindowViewModel"),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}