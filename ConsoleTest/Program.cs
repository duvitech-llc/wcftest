using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfTrackerService;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding,
        new EndpointAddress("http://localhost:8000/OperationService"));

            IService1 proxy = factory.CreateChannel();
            string methodFromServer = proxy.GetData(5);

            Console.WriteLine(methodFromServer);

            Console.ReadLine();
        }
    }
}
