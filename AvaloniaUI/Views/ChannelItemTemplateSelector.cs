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
        public IDataTemplate Normal { get; set; }

        public IDataTemplate Highlighted { get; set; }

        public IControl Build(object param)
        {
            var viewModel = (ChannelViewModel)param;

            if (viewModel == null)
            {
                return this.Normal.Build(param);
            }

            if (viewModel.Highlight)
            {
                return this.Highlighted.Build(param);
            }

            return this.Normal.Build(param);
        }

        public bool Match(object data)
        {
            return true;
        }
    }
}
