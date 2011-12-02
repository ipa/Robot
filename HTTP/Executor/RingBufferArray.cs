using System;
using System.Collections.Generic;
using System.Text;

namespace Executor
{
	public class RingBufferArray
	{
		protected Object[] array;
		protected int front = 0;
		protected int rear = 0;
		private Object putLock = new Object(); 
		private Object getLock = new Object(); 
		
		public RingBufferArray(int n) {
			array = new Object[n];
		}
		
		public void Put(Object x) {
			lock (putLock) {
				array[rear] = x;
				rear = (rear + 1) % array.GetLength(0);
			}
		}

		public Object Get() {
			lock (getLock) {
				Object x = array[front];
				array[front] = null;
				front = (front + 1) % array.GetLength(0);
				return x;
			}
		}
	}
}
