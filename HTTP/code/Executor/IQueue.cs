using System;
using System.Collections.Generic;
using System.Text;

namespace Executor
{
	public interface IQueue
	{
		void Enqueue(Object x); 
		Object Dequeue();
	}
}
