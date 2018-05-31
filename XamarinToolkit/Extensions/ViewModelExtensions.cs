using System.Threading.Tasks;
using Diversido.XamarinToolkit.ViewModels.Abstraction;

namespace Diversido.XamarinToolkit.Extensions
{
	public static class ViewModelExtensions
	{
		internal static TaskWrapper WrapTask (this Task task, IViewModelBase vm)
		{
			return new TaskWrapper (vm, task);
		}

		internal static TaskWrapper WrapTaskDefault (this Task task, IViewModelBase vm)
		{
			return new TaskWrapper (vm, task).WrapDefault ();
		}

		internal static TaskWrapper WrapTaskWithSelectionLoading (this Task task, IViewModelBase vm)
		{
			return new TaskWrapper (vm, task).WrapWithSelectionLoading ();
		}

		internal static TaskWrapper WrapTaskWithSilentLoading (this Task task, IViewModelBase vm)
		{
			return new TaskWrapper (vm, task).WrapWithSilentLoading ();
		}
	}
}
