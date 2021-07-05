using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Input;
using AvaloniaUI.DbServices;
using AvaloniaUI.ViewModels;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace OlimpoMediaCenter.AvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private readonly IChannelsContext _dbContext;

        public ObservableCollection<ChannelsRowViewModel> ChannelsMatrix { get; private set; }

        public ICommand KeyDownPressedCommand { get; }

        public MainWindowViewModel(IChannelsContext dbContext)
        {
            this._dbContext = dbContext;

            this.ChannelsMatrix = new ObservableCollection<ChannelsRowViewModel>();

            this.KeyDownPressedCommand = ReactiveCommand.Create<KeyEventArgs, Unit>(this.OnKeyDownPressed);

            this.WhenActivated(async (d) => await OnActivated(d));
        }

        private async Task OnActivated(CompositeDisposable d)
        {
            var channels = await this._dbContext.Channels
                .Select(x => new ChannelViewModel(x))
                .ToListAsync();

            var currentRow = 0;
            var currentColumn = 0;
            var maxColumns = 5;
            var maxRows = (int)Math.Ceiling((double)channels.Count / maxColumns) + 1;

            var row = new ChannelsRowViewModel(currentRow);

            foreach (var channel in channels)
            {
                channel.ColumnId = currentColumn;
                row.ChannelsRow.Add(channel);

                currentColumn ++;

                if (currentColumn > maxColumns)
                {
                    currentColumn = 0;
                    currentRow ++;
                    
                    this.ChannelsMatrix.Add(row);

                    row = new ChannelsRowViewModel(currentRow);
                }
            }

            // Auto-Select first element of the matrix
            this.ChannelsMatrix
                .Single(x => x.Id == 0)
                .ChannelsRow.Single(x => x.ColumnId == 1)
                .Highlight = true;
        }

        private Unit OnKeyDownPressed(KeyEventArgs arg)
        {
            return Unit.Default;
        }
    }
}