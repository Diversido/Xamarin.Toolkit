using System.Threading.Tasks;

namespace Diversido.Toolkit.ViewModels.Abstraction
{
	public interface IViewModelBase
	{
		bool IsBusy { get; set; }

		Task WrapWithConnectivityCheck (Task task, bool throwOnFail);
		Task WrapWithExceptionHandling (Task task);

		Task WrapWithLoading (Task task);
	}
}
