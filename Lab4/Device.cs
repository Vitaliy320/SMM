using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    public class Device : ControllerBase
    {
        CustomQueue queue;
        double mu;
        public Device(double _mu, CustomQueue queue) 
        {

            this.mu = _mu;
            resetEvent = new AutoResetEvent(true);
            this.queue = queue;
        }

        public void SetResetEvent(bool busy) 
        {
            if (busy)
            {
                resetEvent.WaitOne();
            }
            else
            {
                resetEvent.Set();
            }
        }
        public void process(Customer customer) 
        {
            int time = (int)(1.0 / mu * 1000);
            Thread.Sleep(time);
        }

    }
}
