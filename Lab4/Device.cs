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

        double value;

        WorkMode mode;

        public Device(double value, CustomQueue queue, NextAction action, WorkMode mode) 
        {
            NextAction = action;
            this.value = value;
            resetEvent = new AutoResetEvent(true);
            this.queue = queue;
            this.mode = mode;
        }

        public int Process(Customer customer) 
        {
            int time = 0;
            if(mode == WorkMode.Intensity)
            {
                time = (int)(1.0 / value * Settings.TimeMeasure);
            }
            else if(mode == WorkMode.Time)
            {
                time = (int)value;
            }

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
