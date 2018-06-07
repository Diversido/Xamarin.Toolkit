using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Diversido.Toolkit
{
	public struct TaskWrapper
	{
		Task task;

		internal TaskWrapper (Task task)
		{
			this.task = task;
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
