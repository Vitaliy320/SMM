using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class CustomQueue : ControllerBase
    {
        private bool _reachedLimit;
        Queue<Customer> customersList; 

        public bool HasLimit { get; }
        int limit;

        public event EventHandler queueHandler;
        public CustomQueue()
        {
            _reachedLimit = false;
            HasLimit = false;
            customersList = new Queue<Customer>();
            resetEvent = new System.Threading.AutoResetEvent(true);
        }

        public CustomQueue(int limit)
        {
            _reachedLimit = false;
            this.limit = limit;
            HasLimit = true;
        }
        public Customer FirstCustomerOfQueue() 
        {
            if (_reachedLimit)
            {
                resetEvent.Set();
                queueHandler?.Invoke(this, new QueueEventArgs { Busy = false });
            }
            return customersList.Dequeue();
        }
        public void moveToQueue(Customer customer)
        {
            if (HasLimit)
            {
                if(customersList.Count > limit)
                {
                    _reachedLimit = true;
                    queueHandler?.Invoke(this, new QueueEventArgs { Busy = true });
                    resetEvent.WaitOne();
                }
            }
            customersList.Enqueue(customer);
        }
    }
}
