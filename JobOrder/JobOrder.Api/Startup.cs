using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JobOrder.Application.JobOrders.Commands.CreateJobOrder;
using JobOrder.Application.Infrastructure;

using JobOrder.Application.Interfaces;
using JobOrder.Application.JobOrders.Queries.GetJobOrder;

using NSwag.AspNetCore;
using System.Reflection;
using JobOrder.Api.Filters;
using JobOrder.Infrastructure;
using JobOrder.Application.Infrastructure.AutoMapper;
using JobOrder.Domain;

namespace JobOrder.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
      // Add AutoMapper
      services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

      // Add framework services.
      services.AddTransient<INotificationService, NotificationService>();

      // Add MediatR
      services.AddMediatR(typeof(GetJobOrderQueryHandler).GetTypeInfo().Assembly);
      services.AddMediatR(typeof(JobOrderCreatedHandler).GetTypeInfo().Assembly);
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

      services
          .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
          .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
          .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateJobOrderCommandValidator>());

      // Customise default API behavour
      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.SuppressModelStateInvalidFilter = true;
      });
      services.AddSwaggerDocument();
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      // Register the Swagger generator and the Swagger UI middlewares
      app.UseOpenApi();
      app.UseSwaggerUi3();
      app.UseMvc();
        }
    }
}
