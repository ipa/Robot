using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Executor
{
	public class BoundedBufferWithSemaphor : IQueue
	{
		protected Semaphore empty;
		protected Semaphore full;
		protected RingBufferArray buf;
		
		public BoundedBufferWithSemaphor(int size) 
		{
			buf = new RingBufferArray(size);
			empty = new Semaphore(size,size);
			full = new Semaphore(0,size);
		}
		
		public void Enqueue(Object x) 
		{
			empty.WaitOne();
			buf.Put(x);
			full.Release();
		}

		public Object Dequeue() 
		{
			full.WaitOne();
			Object x = buf.Get();
			empty.Release();
			return x;
		}
	}
}
