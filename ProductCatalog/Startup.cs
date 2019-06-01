using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Data;
using ProductCatalog.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductCatalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // ResponseCompression é uma maneira de reduzir os tamanhos de carga útil é compactar as respostas de um aplicativo.
            services.AddResponseCompression();

            //AddScoped busca se existe um instancia, e se não existe ele cria, se não retorna a existente
            services.AddScoped<StoreDataContext, StoreDataContext>();
            //AddTransiente sempre cria uma nova instancia do serviço passado
            //services.AddTransiente<'Servico', 'Instancia'>();
            services.AddTransient<ProductRepository, ProductRepository>();

            services.AddSwaggerGen(x=>
            {
                x.SwaggerDoc("v1", new Info { Title = "Balta Store", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API - v1");
            });
            // Pagina com documentação: '/swagger/index.html'
        }
    }
}
