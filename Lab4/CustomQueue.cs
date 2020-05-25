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

        public CustomQueue()
        {
            _reachedLimit = false;
            HasLimit = false;
            customersList = new Queue<Customer>();
            resetEvent = new System.Threading.AutoResetEvent(false);
        }

        public CustomQueue(int limit)
        {
            _reachedLimit = false;
            this.limit = limit;
            HasLimit = true;
            customersList = new Queue<Customer>();
            resetEvent = new System.Threading.AutoResetEvent(false);
        }
        public Customer FirstCustomerOfQueue() 
        {
            if(customersList.Count <= 0)
            {
                resetEvent.WaitOne();
            }

            if (_reachedLimit)
            {
                _reachedLimit = false;
                resetEvent.Set();
              
            }
            return customersList.Dequeue();
        }
        public  void MoveToQueue(Customer customer)
        {
            if (HasLimit)
            {
                if(customersList.Count >= limit)
                {
                    _reachedLimit = true;
                    resetEvent.Reset();
                    resetEvent.WaitOne();
                }
            }

            customersList.Enqueue(customer);
            if (customersList.Count == 1)
            {
                resetEvent.Set();
            }
        }
    }
}
