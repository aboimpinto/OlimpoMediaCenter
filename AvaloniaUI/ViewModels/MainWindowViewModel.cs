using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using AvaloniaUI.DbServices;
using AvaloniaUI.Extensions;
using MediaCenter.Model;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace OlimpoMediaCenter.AvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private string _greeting = string.Empty;
        private readonly IChannelsContext _dbContext;

        public ObservableCollection<Channel> Channels { get; private set; }

        public string Greeting 
        { 
            get => this._greeting;
            set => this.RaiseAndSetIfChanged(ref this._greeting, value);
        }

        public MainWindowViewModel(IChannelsContext dbContext)
        {
            this._dbContext = dbContext;

            this.Channels = new ObservableCollection<Channel>();

            this.WhenActivated(async (d) => await OnActivated(d));
        }

        private async Task OnActivated(CompositeDisposable d)
        {
            var channels = await this._dbContext.Channels.ToListAsync();
            this.Channels.AddEntities(channels);

            this.Greeting = $"Hello World from OnActivated : {this.Channels.Count}";
        }
    }
}