using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educative.API.Extension
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsService(this IServiceCollection services){
            return services.AddCors();
        }
    }
}