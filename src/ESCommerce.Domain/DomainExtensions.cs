using ESCommerce.Domain.Boxes.Commands;
using ESCommerce.Domain.Products.Commands;
using JasperFx.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain
{
    public static class DomainExtensions
    {
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.AddScoped<CommandRouter>();
            ///
            /// <title>Box Aggregate</title>
            ///
            services.AddTransient<ICommandHandler<CreateBoxCommand>, CreateBoxCommandHandler>();
            services.AddTransient<ICommandHandler<CloseBoxCommand>, CloseBoxCommandHandler>();
            services.AddTransient<ICommandHandler<SendBoxCommand>, SendBoxCommandHandler>();
            services.AddTransient<ICommandHandler<AddShippingLabelCommand>, AddShippingLabelCommandHandler>();
            services.AddTransient<ICommandHandler<AddProductCommand>, AddProductCommandHandler>();
            services.AddTransient<ICommandHandler<CreateBoxCommand>, CreateBoxCommandHandler>();
            ///
            /// <title>product Aggregate</title>
            ///
            services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.AddTransient<ICommandHandler<AddVariationCommand>, AddVariationCommandHandler>();
            services.AddTransient<ICommandHandler<AttachImageCommand>, AttachImageCommandHandler>();

        }
    }
}
