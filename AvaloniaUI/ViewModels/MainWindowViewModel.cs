using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using ReactiveUI;
using OlimpoMediaCenter.AvaloniaUI.DbServices;

namespace OlimpoMediaCenter.AvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private string _greeting = string.Empty;

        public string Greeting 
        { 
            get => this._greeting;
            set => this.RaiseAndSetIfChanged(ref this._greeting, value);
        }

        public MainWindowViewModel(IChannelsService channelsService)
        {
            this.WhenActivated(async (d) => await OnActivated(d));
        }

        private async Task OnActivated(CompositeDisposable d)
        {
            Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: MainWindowViewModel: OnActivated");

            this.Greeting = "Hello World from OnActivated";

            await Task.FromResult(Task.CompletedTask);
        }
    }
}
