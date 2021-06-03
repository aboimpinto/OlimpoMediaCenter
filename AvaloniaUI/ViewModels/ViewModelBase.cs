using System;
using System.Diagnostics;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using ReactiveUI;

namespace OlimpoMediaCenter.AvaloniaUI.ViewModels
{
    public class ViewModelBase : ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }

        public ViewModelBase() : base()
        {
            this.Activator = new ViewModelActivator();

            this.WhenActivated(async disposables => await OnActivated(disposables));
        }

        private async Task OnActivated(CompositeDisposable disposables)
        { 
            Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: ViewModelBase: OnActivated");

			try
			{

				Disposable
					.Create(() => Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: ViewModelBase: Deactivated."))
					.DisposeWith(disposables);
			}
			catch (Exception ex)
			{
				string msg = $"{ex.Message}:{Environment.NewLine}{ex.StackTrace}";
				Debug.WriteLine($"{DateTime.Now:dd HH:mm:ss.fffff}: ViewModelBase: Exception: ({msg})");
			}

			await Task.FromResult(Task.CompletedTask);
        }
    }
}
