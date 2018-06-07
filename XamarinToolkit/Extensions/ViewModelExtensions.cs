using System.Threading.Tasks;

namespace Diversido.Toolkit.Extensions
{
	public static class ViewModelExtensions
	{
		internal static TaskWrapper WrapTask (this Task task)
		{
			return new TaskWrapper (task);
		}
	}
}
