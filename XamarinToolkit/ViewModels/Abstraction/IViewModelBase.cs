using System.Threading.Tasks;

namespace Diversido.XamarinToolkit.ViewModels.Abstraction
{
	public interface IViewModelBase
	{
		bool IsLoading { get; set; }
		bool IsSilentLoading { get; set; }
		bool IsSelectionLoading { get; set; }

		Task WrapWithConnectivityCheck (Task task, bool throwOnFail);
		Task WrapWithExceptionHandling (Task task);

		Task WrapWithLoading (Task task);
		Task WrapWithSilentLoading (Task task);
		Task WrapWithSelectionLoading (Task task);
	}
}
