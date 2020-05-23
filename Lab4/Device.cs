using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    public delegate void NextAction(Customer customer);

    public class Device : ControllerBase
    {

        public NextAction NextAction;

        CustomQueue queue;
        double mu;
        public Device(double _mu, CustomQueue queue, NextAction action) 
        {
            NextAction = action;
            this.mu = _mu;
            resetEvent = new AutoResetEvent(true);
            this.queue = queue;
        }

        public int Process(Customer customer) 
        {
            int time = (int)(1.0 / mu * 1000);

            return time;
        }

        public void ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var customer = queue.FirstCustomerOfQueue();

                int time = Process(customer);
                Thread.Sleep(time);

                NextAction(customer);
            }
        }

    }
}
