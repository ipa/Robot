using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Executor
{
	public class PlainThreadExecutor : IExecutor
	{
		public void Execute(ThreadStart threadStart)
		{
			new Thread(threadStart).Start();
		}
	}
}
