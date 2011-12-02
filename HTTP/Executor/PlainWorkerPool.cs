using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Executor
{
	public class PlainWorkerPool : IExecutor
	{
		protected IQueue workQueue;
		private bool busy = true;
		private int nWorkers;

		public PlainWorkerPool(IQueue workQueue, int nWorkers)
		{
			this.nWorkers = nWorkers;
			this.workQueue = workQueue;
			for (int i = 0; i < nWorkers; ++i)
				activate();
		}

		public void Execute(ThreadStart threadStart)
		{
			workQueue.Enqueue(threadStart);
		}

		protected void activate() 
		{
			Thread runLoop = new Thread(delegate() {
				while(busy) {
					ThreadStart threadStart = (ThreadStart)workQueue.Dequeue();
					threadStart.Invoke();
				}
			});
			runLoop.Start();
		}

		public void ShutDown()
		{
			busy = false;
			for (int i = 0; i < nWorkers; i++)
			{
				Execute(new ThreadStart(delegate() { }));
			}
		}
	}
}

