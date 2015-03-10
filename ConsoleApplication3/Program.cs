using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfTrackerService;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();

            Uri serviceUri = new Uri("http://localhost:8800");
            ServiceHost host = new ServiceHost(typeof(Service1), serviceUri);
            host.AddServiceEndpoint(typeof(IService1), binding, "OperationService");
            
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            Binding mexBinding = MetadataExchangeBindings.CreateMexHttpBinding();
            host.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "mex");
            host.Open();
            
            Console.WriteLine("Service is hosted to the Server");
            Console.ReadLine();

            host.Close();

        }
    }
}
