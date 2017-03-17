using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using TexasHoldEmService;

namespace TexasHoldEmHost
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8000/Service1"));
            try
            {
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WSDualHttpBinding(), "");
                host.Open();
                Console.WriteLine("http://localhost:8000/Service1");
                Console.WriteLine("Service is running");
                Console.WriteLine("Press enter to quit...");
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                Console.ReadKey();
                host.Abort();
            }
        }
    }
}
