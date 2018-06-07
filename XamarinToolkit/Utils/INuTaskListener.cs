using System;
namespace Diversido.Toolkit.Utils
{
	public interface INuTaskListener
	{
		void Started ();
		void Finished ();
		void Failed (Exception exception);
	}
}
