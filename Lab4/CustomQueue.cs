using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public class CustomQueue : ControllerBase
    {
        private bool _reachedLimit;
        Queue<Customer> customersList;

        private bool HasLimit { get; }
        int limit;
        
        public string Name { get; set; }

        string path = @"C:\Users\Evgentus\Desktop\SmmLogs\QueueValues";

        public CustomQueue(string name)
        {
            Name = name;
            _reachedLimit = false;
            HasLimit = false;
            customersList = new Queue<Customer>();
            resetEvent = new System.Threading.AutoResetEvent(false);

            new Thread(UpdateTextBox).Start();
        }

        public CustomQueue(string name, int limit)
        {
            Name = name;
            _reachedLimit = false;
            this.limit = limit;
            HasLimit = true;
            customersList = new Queue<Customer>();
            resetEvent = new System.Threading.AutoResetEvent(false);

            new Thread(UpdateTextBox).Start();
        }

        private void UpdateTextBox()
        {
            Thread.Sleep(500);
            double time = 1;
            double count = 0;

            while (true)
            {
                Thread.Sleep((int)Settings.TimeMeasure * 100);

                count += this.customersList.Count;
                var mes = (count / time).ToString();
                using (var file = new StreamWriter($"{path}\\{Name}.txt"))
                {
                    file.WriteLine(mes);
                }
                

                time++;
            }
            
        }

        public Customer FirstCustomerOfQueue()
        {

            if (customersList.Count <= 0)
            {
                resetEvent.Reset();
                resetEvent.WaitOne();
            }

            if (_reachedLimit)
            {
                _reachedLimit = false;
                resetEvent.Set();
            }
            var customer = customersList.Dequeue();

            customer.CreateMessage($"Dequeue in queue {Name}");
            customer.WriteToFile($"Dequeue in queue, {Name}");
            return customer;
        }
        public void MoveToQueue(Customer customer)
        {
            if (HasLimit)
            {
                if (customersList.Count >= limit)
                {
                    _reachedLimit = true;
                    resetEvent.Reset();
                    resetEvent.WaitOne();
                }
            }

            customer.CreateMessage($"Enqueue in queue {Name}");
            customer.WriteToFile($"Enqueue in queue, {Name}");

            customersList.Enqueue(customer);
            if (customersList.Count == 1)
            {
                resetEvent.Set();
            }
        }
    }
}
