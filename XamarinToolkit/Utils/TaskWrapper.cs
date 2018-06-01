using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Diversido.Toolkit.ViewModels.Abstraction;

namespace Diversido.Toolkit
{
	public struct TaskWrapper
	{
		Task task;

		readonly IViewModelBase viewModel;

		internal TaskWrapper (IViewModelBase viewModel, Task task)
		{
			this.viewModel = viewModel;
			this.task = task;
		}

		internal TaskWrapper WrapWithConnectivityCheck (bool throwOnFail = false)
		{
			task = viewModel.WrapWithConnectivityCheck (task, throwOnFail);
			return this;
		}

		internal TaskWrapper WrapWithExceptionHandling ()
		{
			task = viewModel.WrapWithExceptionHandling (task);
			return this;
		}

		internal TaskWrapper WrapWithLoading ()
		{
			task = viewModel.WrapWithLoading (task);
			return this;
		}

		internal TaskWrapper WrapWithSelectionLoading()
		{
			task = viewModel.WrapWithSelectionLoading (task);
			return this;
		}

		internal TaskWrapper WrapWithSilentLoading ()
		{
			task = viewModel.WrapWithSilentLoading (task);
			return this;
		}

		// Default wrapper for the application
		internal TaskWrapper WrapDefault ()
		{
			return WrapWithConnectivityCheck (true).WrapWithExceptionHandling ().WrapWithLoading ();
		}

		// To enable using the class along with the 'await' keyword
		public TaskAwaiter GetAwaiter ()
		{
			return task.GetAwaiter ();
		}

		// Shortcut for the 'ConfigureAwait (false)'
		public static ConfiguredTaskAwaitable operator !(TaskWrapper wrapper)
		{
			return wrapper.task.ConfigureAwait (false);
		}
	}
}
