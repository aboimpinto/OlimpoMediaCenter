using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Input;
using AvaloniaUI.DbServices;
using AvaloniaUI.Extensions;
using AvaloniaUI.ViewModels;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace OlimpoMediaCenter.AvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private string _greeting = string.Empty;
        private readonly IChannelsContext _dbContext;

        public ObservableCollection<ChannelViewModel> Channels { get; private set; }

        public ObservableCollection<ObservableCollection<ChannelViewModel>> ChannelsMatrix { get; private set; }

        public ICommand KeyDownPressedCommand { get; }

        public string Greeting 
        { 
            get => this._greeting;
            set => this.RaiseAndSetIfChanged(ref this._greeting, value);
        }

        public MainWindowViewModel(IChannelsContext dbContext)
        {
            this._dbContext = dbContext;

            this.Channels = new ObservableCollection<ChannelViewModel>();
            this.ChannelsMatrix = new ObservableCollection<ObservableCollection<ChannelViewModel>>();

            this.KeyDownPressedCommand = ReactiveCommand.Create<KeyEventArgs, Unit>(this.OnKeyDownPressed);

            this.WhenActivated(async (d) => await OnActivated(d));
        }

        private async Task OnActivated(CompositeDisposable d)
        {
            var channels = await this._dbContext.Channels
                .Select(x => new ChannelViewModel(x))
                .ToListAsync();
            this.Channels.AddEntities(channels);

            var currentListMatrix = new ObservableCollection<ChannelViewModel>();

            var currentRow = 0;
            var currentColumn = 0;
            var maxColumns = 5;
            var maxRows = (int)Math.Ceiling((double)this.Channels.Count / maxColumns) + 1;
            foreach (var channel in this.Channels)
            {
                currentListMatrix.Add(channel);
                currentColumn ++;

                if (currentColumn > maxColumns)
                {
                    currentColumn = 0;
                    currentRow ++;
                    this.ChannelsMatrix.Add(currentListMatrix);
                    currentListMatrix = new ObservableCollection<ChannelViewModel>();
                }
            }

            // Auto-Select first element of the matrix
            this.ChannelsMatrix.First().First().Highlight = true;

            this.Greeting = $"Hello World from OnActivated : {this.Channels.Count}";
        }

        private Unit OnKeyDownPressed(KeyEventArgs arg)
        {
            return Unit.Default;
        }
    }
}