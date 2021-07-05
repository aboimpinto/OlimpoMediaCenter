using Avalonia;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using OlimpoMediaCenter.AvaloniaUI.ViewModels;

namespace OlimpoMediaCenter.AvaloniaUI.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void lbox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}