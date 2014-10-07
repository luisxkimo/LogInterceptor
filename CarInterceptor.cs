using Castle.DynamicProxy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInterceptor
{
	public class CarInterceptor : IInterceptor
	{
        private static readonly ILog logger = LogManager.GetLogger("Program");
		public void Intercept(IInvocation invocation)
		{
            logger.InfoFormat("TargetType: {0}, Method: {1}, Parameters: {2}", 
				invocation.TargetType.Name, 
				invocation.Method.Name, 
				FormatParameters(invocation.Arguments));
            invocation.Proceed();

		}

        private static object FormatParameters(IEnumerable<object> parameters)
        {
            return string.Join(", ", parameters.Select(x => FormatParameter(x)).ToArray());
        }

		private static string FormatParameter(object parameter)
		{
			if (parameter == null)
				return "[null]";
			var s = parameter.ToString();
			return s.Length > 100 ? s.Substring(0, 97) + "..." : s;
		}

	}
}
