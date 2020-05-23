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

        List<Customer> servedCustomers;
        Device device1;
        Device device2;
        Device device3;
        private const int QUEUE_2_LIMIT = 10;
        private const double DEVICE_1_MU = 0.2, DEVICE_2_MU = 0.05, DEVICE_3_MU = 0.05;
        public Source()
        {
            servedCustomers = new List<Customer>();

            settings = new Settings();
            queue1 = new CustomQueue();
            queue2 = new CustomQueue(QUEUE_2_LIMIT);
            device1 = new Device(DEVICE_1_MU, queue1,  x =>  queue2.MoveToQueue(x));

            device2 = new Device(DEVICE_2_MU, queue2,  x => servedCustomers.Add(x));
            device3 = new Device(DEVICE_3_MU, queue2,  x => servedCustomers.Add(x));
        }
        
        
        public async Task ExecuteAsync(CancellationToken stoppingToken) 
        {
            var thread1 = new Thread(() => device1.ExecuteAsync(stoppingToken));
            thread1.Name = "Device1";


            var thread2 = new Thread(() => device2.ExecuteAsync(stoppingToken));
            thread2.Name = "Device2";

            var thread3 = new Thread(() => device3.ExecuteAsync(stoppingToken));
            thread3.Name = "Device3";

            thread1.Start();
            thread2.Start();
            thread3.Start();

            int delayTime = settings.Delay;
            while (!stoppingToken.IsCancellationRequested)
            {
                Customer customer = new Customer();
                queue1.MoveToQueue(customer);

                Thread.Sleep(delayTime);
            }
        }
    }
}
