using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Executor
{
	public class WorkerPool : IExecutor
	{
		public WorkerPool(int nWorkers)
		{
			ThreadPool.SetMaxThreads(nWorkers,nWorkers);
		}

		public void Execute(ThreadStart threadStart)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Work),threadStart);
		}

		protected void Work(Object todo)
		{
			ThreadStart threadStart = (ThreadStart)todo;
			threadStart.Invoke();
		}
	}
}
