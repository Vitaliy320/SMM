using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
{
    public class Source
    {

        Settings settings;
        CustomQueue queue1;
        CustomQueue queue2;
        Device device1;
        Device device2;
        Device device3;
        private const int QUEUE_2_LIMIT = 10;
        private const double DEVICE_1_MU = 0.2, DEVICE_2_MU = 0.05, DEVICE_3_MU = 0.05;
        public Source()
        {
            settings = new Settings();
            queue1 = new CustomQueue();
            queue2 = new CustomQueue(QUEUE_2_LIMIT);
            device1 = new Device(DEVICE_1_MU, queue1);
            device2 = new Device(DEVICE_2_MU, queue2);
            device3 = new Device(DEVICE_3_MU, queue2);
        }
        
        
        protected async Task ExecuteAsync(CancellationToken stoppingToken) 
        {
            int delayTime = settings.Delay;
            while (!stoppingToken.IsCancellationRequested)
            {
                Thread.Sleep(delayTime);
                Customer customer = new Customer();
                await Task.Run(() => StartSimulation(customer));
            }
        }

        private void StartSimulation(Customer customer) 
        {
            queue1.moveToQueue(customer);
            var firstCustomerFromQueue = queue1.FirstCustomerOfQueue();
        }
    }
}
