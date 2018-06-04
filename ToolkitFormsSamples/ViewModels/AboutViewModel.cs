using System;
using System.Windows.Input;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace ToolkitFormsSamples.ViewModels
{
	public class AboutViewModel: BaseViewModel
	{
		public AboutViewModel ()
		{
			Title = "About";

			OpenWebCommand = new Command (() => Device.OpenUri (new Uri ("https://xamarin.com/platform")));
			DoSmthCommand = new Command (() => DoSmthAsync ());
		}

		public ICommand OpenWebCommand { get; }
		public ICommand DoSmthCommand { get; }

		async Task DoSmthAsync()
		{
			for (int i = 0; i < 5; i++)
			{
				System.Diagnostics.Debug.WriteLine ($"Testing: {i}");
				await Task.Delay (250);
			}
		}
	}
}