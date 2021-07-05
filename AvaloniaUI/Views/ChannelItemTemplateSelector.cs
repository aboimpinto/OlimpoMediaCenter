using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;
using AvaloniaUI.ViewModels;

namespace AvaloniaUI.Views
{
    public class ChannelItemTemplateSelector : IDataTemplate
    {
        [Content]
        public Dictionary<string, IDataTemplate> Templates { get; } = new Dictionary<string, IDataTemplate>();

        public IControl Build(object param)
        {
            var viewModel = (ChannelViewModel)param;

            if (viewModel == null)
            {
                return (IControl)this.Templates.First().Value.Build(param);
            }

            if (viewModel.Highlight)
            {
                return (IControl)this.Templates.Single(x => x.Key == "ChannelMatrixItemHighlighted").Value.Build(param);
            }

            return (IControl)this.Templates.Single(x => x.Key == "ChannelMatrixItem").Value.Build(param);
        }

        public bool Match(object data)
        {
            return true;
        }
    }
}
