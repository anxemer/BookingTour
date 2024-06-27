using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repostitory
{
    public class GenericBackendService
    {
        private readonly IServiceProvider _serviceProvider;
        public GenericBackendService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T? Resolve<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T))!;
        }
    }
}
