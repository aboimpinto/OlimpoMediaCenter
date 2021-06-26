using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using AvaloniaUI.DbServices;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
// using OlimpoMediaCenter.AvaloniaUI.DbServices;

namespace OlimpoMediaCenter.AvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private string _greeting = string.Empty;
        private readonly IChannelsContext _dbContext;

        public string Greeting 
        { 
            get => this._greeting;
            set => this.RaiseAndSetIfChanged(ref this._greeting, value);
        }

        public MainWindowViewModel(IChannelsContext dbContext)
        {
            this._dbContext = dbContext;

            this.WhenActivated(async (d) => await OnActivated(d));
        }

        private async Task OnActivated(CompositeDisposable d)
        {
            Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: MainWindowViewModel: OnActivated");

            var channelCount = await this._dbContext.Channels.CountAsync();

            this.Greeting = $"Hello World from OnActivated : {channelCount}";

            await Task.FromResult(Task.CompletedTask);
        }
    }
}
