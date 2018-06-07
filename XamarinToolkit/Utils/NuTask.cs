using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Diversido.Toolkit.ViewModels.Abstraction;
using System.Threading.Tasks;

namespace Diversido.Toolkit.Utils
{
	public struct NuTaskMethodBuilder
	{
		AsyncTaskMethodBuilder _asyncBuilder;

		public static NuTaskMethodBuilder Create ()
		{
			var nuBuilder = new NuTaskMethodBuilder ();
			var asyncBuilder = AsyncTaskMethodBuilder.Create ();

			nuBuilder.task = new NuTask ();
			nuBuilder.task.innerTask = asyncBuilder.Task;

			nuBuilder._asyncBuilder = asyncBuilder;

			return nuBuilder;
		}

		public void SetResult () 
		{
			_asyncBuilder.SetResult ();
			Task?.Bindable?.Finished ();
		}

		public void Start<TStateMachine> (ref TStateMachine stateMachine)
			where TStateMachine : IAsyncStateMachine
		{
			_asyncBuilder.Start (ref stateMachine);
		}

		NuTask task;
		public NuTask Task => task;

		public void SetException (Exception exc)
		{
			_asyncBuilder.SetException (exc);
			Task?.Bindable?.Finished ();

			if (Task?.Bindable == null) throw exc;

			Task.Bindable.Failed (exc);
		}

		public void AwaitOnCompleted<TAwaiter, TStateMachine> (ref TAwaiter awaiter, ref TStateMachine stateMachine)
			where TAwaiter : INotifyCompletion
			where TStateMachine : IAsyncStateMachine
		{
			_asyncBuilder.AwaitOnCompleted (ref awaiter, ref stateMachine);
		}

		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine> (ref TAwaiter awaiter, ref TStateMachine stateMachine)
			where TAwaiter : ICriticalNotifyCompletion
			where TStateMachine : IAsyncStateMachine
		{
			_asyncBuilder.AwaitUnsafeOnCompleted (ref awaiter, ref stateMachine);
		}

		public void SetStateMachine (IAsyncStateMachine stateMachine)
		{
			_asyncBuilder.SetStateMachine (stateMachine);
		}
	}

	[AsyncMethodBuilder (typeof (NuTaskMethodBuilder))]
	public class NuTask
	{
		internal Task innerTask;

		public INuTaskListener Bindable { get; private set; }

		public NuTaskAwaiter GetAwaiter ()
		{
			return default (NuTaskAwaiter);
		}

		public NuTask ListenTo (INuTaskListener bindable)
		{
			bindable?.Started ();
			Bindable = bindable;

			return this;
		}

		public ConfiguredTaskAwaitable DetachFromContext()
		{
			return innerTask.ConfigureAwait (false);
		}

		public static ConfiguredTaskAwaitable operator - (NuTask nu)
		{
			return nu.DetachFromContext ();
		}
	}

	public struct NuTaskAwaiter: INotifyCompletion
	{
		public void GetResult () { }

		public bool IsCompleted => false;

		public void OnCompleted (Action continuation)
		{
			continuation?.Invoke ();
		}
	}
}
