using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WeChatPay.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWeChatPay(this IServiceCollection services)
        {
            services.AddTransient<IWeChatPayManager, WeChatPayManager>();
        }


    }
}
