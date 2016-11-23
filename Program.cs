using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using Backend.Controllers;
using Backend.Model;
using Backend.Services;

namespace Backend
{
    [ServiceContract]
    public interface IServiceClass
    {
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "elementaryAreas/"

            ), OperationContract]
        string GetElementaryAreas();

        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/{*content}")]
        Stream StaticContent(string content);
    }

    public class ServiceClass : IServiceClass
    {
        private readonly ElementaryAreaController _controller;

        public ServiceClass()
        {
            var queryBuilder = new QueryBuilder();

            _controller = new ElementaryAreaController(new ElementaryAreaService(
                new DbConnectionService(new DatabaseLocator()),
                new EntityLoader<ElementaryAreaFullModel>(queryBuilder),
                new EntityLoader<ElementaryAreaHistoryIItem>(queryBuilder),
                new EntityLoader<ElementaryAreaSoilComposition>(queryBuilder),
                new EntityLoader<PaymentCropFullModel>(queryBuilder),
                new EntityLoader<MineralFertilizerFullModel>(queryBuilder),
                new EntityLoader<OrganicFertilizerFullModel>(queryBuilder)          
            ));
        }

        public string GetElementaryAreas()
        {
            return _controller.List();
        }

        public Stream StaticContent(string content)
        {
            var response = WebOperationContext.Current.OutgoingResponse;
            content = content.Replace('/', '.').Replace('\\', '.');
            var path = "Backend.Static." + (string.IsNullOrEmpty(content) ? "index.html" : content);
            var extension = Path.GetExtension(path);
            var contentType = string.Empty;

            switch (extension)
            {
                case ".htm":
                case ".html":
                    contentType = "text/html";
                    break;
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".ico":
                    contentType = "image/x-icon";
                    break;
                case ".js":
                    contentType = "application/javascript";
                    break;
                case ".json":
                    contentType = "application/json";
                    break;
                case ".css":
                    contentType = "text/css";
                    break;
                case ".eot":
                    contentType = "application/vnd.ms-fontobject";
                    break;
                case ".svg":
                    contentType = "image/svg+xml";
                    break;
                case ".ttf":
                    contentType = "application/x-font-ttf";
                    break;
                case ".woff":
                    contentType = "application/x-font-woff";
                    break;
            }
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            if ((resourceStream?.CanRead ?? false) && !string.IsNullOrEmpty(contentType))
            {
                response.ContentType = contentType;
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return resourceStream;
            }

            response.StatusCode = System.Net.HttpStatusCode.NotFound;
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:8009");

            var host = new WebServiceHost(typeof(ServiceClass), uri);
            var binding = new WebHttpBinding();
            host.AddServiceEndpoint(typeof (IServiceClass), binding, "");
            var stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            stp.HttpHelpPageEnabled = false;

            host.Open();


            Console.WriteLine("Started");
            Process.Start(uri.ToString());
            Console.ReadKey();

        }
    }
}
