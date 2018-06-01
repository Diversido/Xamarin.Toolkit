using System;
using System.Runtime.CompilerServices;
using System.Threading;

public struct DetachSynchronizationContextAwaiter: ICriticalNotifyCompletion
{
	/// <summary>
	/// Returns true if a current synchronization context is null.
	/// It means that the continuation is called only when a current context
	/// is presented.
	/// </summary>
	public bool IsCompleted => SynchronizationContext.Current == null;

	public void OnCompleted (Action continuation)
	{
		ThreadPool.QueueUserWorkItem (state => continuation ());
	}

	public void GetResult () { }

	public DetachSynchronizationContextAwaiter GetAwaiter () => this;

	public void UnsafeOnCompleted (Action continuation)
	{
		// TODO: Fix if the exception will occur. Alternaively - update to .NET Standard 2.0
		throw new NotImplementedException ();
	}
}

public static class Awaiters
{
	public static DetachSynchronizationContextAwaiter DetachCurrentSyncContext ()
	{
		return new DetachSynchronizationContextAwaiter ();
	}
}