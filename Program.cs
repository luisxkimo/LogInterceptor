using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle;
using Castle.DynamicProxy;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using log4net.Config;

namespace LogInterceptor
{
	class Program
	{
		static void Main(string[] args)
		{
            var logConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            XmlConfigurator.Configure(new FileInfo(logConfigPath));

            Console.WriteLine("Iniciando contenedor: ");
			var container = InitializeContainer();

            Console.WriteLine("Iniciamos coche");
       
		    var car = container.Resolve<IAuto>();
            Console.WriteLine("********************");
            Console.WriteLine("Metodos Invocados: \n");
			car.Run(10, Direction.Left);
			car.AddVelocity(5);

		}

		private static WindsorContainer InitializeContainer()
		{
			var container = new WindsorContainer();
		    container.Register(
		        Component.For<CarInterceptor>());

		    container.Register(
		        Component.For(typeof (IAuto)).ImplementedBy(typeof (Car)).Interceptors<CarInterceptor>().LifeStyle.Singleton);

			return container;
		}
	}
}
