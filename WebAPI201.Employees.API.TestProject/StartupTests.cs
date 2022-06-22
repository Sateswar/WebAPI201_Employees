using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI201_Employees;

namespace WebAPI201.Employees.API.TestProject
{
    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        [Obsolete]
        public void StartupTest()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);

            IServiceCollection services=new ServiceCollection();
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI201_Employees", Version = "v1" }); });

            IServiceProvider serviceProvider;

            


            //var env = Microsoft.AspNetCore.Hosting.Environment.GetEnvironmentVariable().value;
            //Assert.IsNotNull(webHost.Services.GetRequiredService<services.AddSwaggerGen>());
            //Assert.IsNotNull(webHost.Services.GetRequiredService<IService2>());
            // Arrange
            var mockEnvironment = new Mock<IHostingEnvironment>();
            //...Setup the mock as needed
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:Development");
            //...other setup for mocked IHostingEnvironment...

            serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService(typeof(Startup));
            Assert.IsNotNull(serviceProvider);


            IApplicationBuilder app = new ApplicationBuilder(serviceProvider);
            app.UseDeveloperExceptionPage();
            app.UseExceptionHandler();
            app.UseHsts();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
           


        }
    }

    
}
