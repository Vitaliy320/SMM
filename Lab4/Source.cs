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
        CustomQueue queue1;
        CustomQueue queue2;

        Device device1;
        Device device2;
        Device device3;

        List<Customer> servedCustomers;

        CustomQueue helpQueue;
        Device helpDevice;

        public Source()
        {
            servedCustomers = new List<Customer>();

            queue1 = new CustomQueue("Queue1", Settings.QUEUE_1_LIMIT);
            queue2 = new CustomQueue("Queue2", Settings.QUEUE_2_LIMIT);

            helpQueue = new CustomQueue("HelpQueue", 1);

            device1 = new Device("Device1", Settings.DEVICE_1_MU, queue1, x => helpQueue.MoveToQueue(x), WorkMode.Intensity);
            device2 = new Device("Device2", Settings.DEVICE_2_TIME, helpQueue, x => queue2.MoveToQueue(x), WorkMode.Time);
            device3 = new Device("Device3", Settings.DEVICE_3_TIME, queue2, x => 
            { 
                servedCustomers.Add(x);
                x.WriteToFile("End Work");
                x.CreateMessage("End Work");
                x.WriteFinalMessage();
            }, WorkMode.Time);

            helpDevice = new Device("HelpDevice", 0, helpQueue, x => queue2.MoveToQueue(x), WorkMode.Time);
        }
        
        
        public void ExecuteAsync(CancellationToken stoppingToken) 
        {
            var thread1 = new Thread(() => device1.ExecuteAsync(stoppingToken));
            thread1.Name = "Device1";

            var thread2 = new Thread(() => device2.ExecuteAsync(stoppingToken));
            thread2.Name = "Device2";

            var thread3 = new Thread(() => device3.ExecuteAsync(stoppingToken));
            thread3.Name = "Device3";

            var thread4 = new Thread(() => helpDevice.ExecuteAsync(stoppingToken));
            thread4.Name = "HelpDevice";

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            int delayTime = Settings.Delay;
            int count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                Customer customer = new Customer($"Customer {count}");

                customer.WriteToFile("Has been created");
                customer.CreateMessage("Has been created");

                queue1.MoveToQueue(customer);

                Thread.Sleep(delayTime);
                count++;
            }
        }
    }
}
