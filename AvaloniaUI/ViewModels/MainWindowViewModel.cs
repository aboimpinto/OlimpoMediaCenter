using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Input;
using Avalonia.Threading;
using AvaloniaUI.DbServices;
using AvaloniaUI.ViewModels;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace OlimpoMediaCenter.AvaloniaUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IActivatableViewModel
    {
        private readonly IChannelsContext _dbContext;
        private int _rowId;
        private int _columnId;

        // private ObservableCollection<ChannelViewModel> _channelsList;

        public ObservableCollection<ChannelsRowViewModel> ChannelsMatrix { get; private set; }

        public ObservableCollection<ChannelViewModel> ChannelsList { get; private set; }
        // { 
        //     get => this._channelsList;
        //     set => this.RaiseAndSetIfChanged(ref this._channelsList, value);
        // }

        public ICommand KeyDownPressedCommand { get; }

        public ICommand MoveDownCommand { get; }

        public MainWindowViewModel(IChannelsContext dbContext)
        {
            this._dbContext = dbContext;

            this.ChannelsMatrix = new ObservableCollection<ChannelsRowViewModel>();
            this.ChannelsList = new ObservableCollection<ChannelViewModel>();

            this.KeyDownPressedCommand = ReactiveCommand.Create<KeyEventArgs, Unit>(this.OnKeyDownPressed);
            this.MoveDownCommand = ReactiveCommand.Create(this.OnMoveDown);

            this._rowId = 0 ;
            this._columnId = 1;

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
                this.ChannelsList.Add(channel);

                currentColumn ++;

                // channel.ColumnId = currentColumn;
                // row.ChannelsRow.Add(channel);

                // currentColumn ++;

                // if (currentColumn > maxColumns)
                // {
                //     currentColumn = 0;
                //     currentRow ++;
                    
                //     this.ChannelsMatrix.Add(row);

                //     row = new ChannelsRowViewModel(currentRow);
                // }
            }

            // Auto-Select first element of the matrix
            // this.ChannelsMatrix
            //     .Single(x => x.Id == this._rowId)
            //     .ChannelsRow.Single(x => x.ColumnId == this._columnId)
            //     .Highlight = true;

            this.ChannelsList
                .Single(x => x.ColumnId == this._columnId)
                .Highlight = true;
        }

        private Unit OnKeyDownPressed(KeyEventArgs arg)
        {
            this.ChannelsList
                .Single(x => x.ColumnId == this._columnId)
                .Highlight = false;

            this._columnId ++;

            this.ChannelsList
                .Single(x => x.ColumnId == this._columnId)
                .Highlight = true;




            // this.ChannelsMatrix
            //     .Single(x => x.Id == this._rowId)
            //     .ChannelsRow.Single(x => x.ColumnId == this._columnId)
            //     .Highlight = false;

            // if (arg.Key == Key.Left)
            // {
            //     this._columnId ++;
            // }

            // this.ChannelsMatrix
            //     .Single(x => x.Id == this._rowId)
            //     .ChannelsRow.Single(x => x.ColumnId == this._columnId)
            //     .Highlight = true;

            return Unit.Default;
        }

        private void OnMoveDown()
        {
            // this.ChannelsList
            //     .Single(x => x.ColumnId == this._columnId)
            //     .Highlight = false;

            foreach(var channel in this.ChannelsList)
            {
                if (channel.ColumnId == this._columnId)
                {
                    channel.Highlight = false;
                    return;
                }
            }

        }

    }
}