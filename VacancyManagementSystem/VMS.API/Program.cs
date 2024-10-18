
using FluentValidation.AspNetCore;
using NLog;
using NLog.Web;
using VMS.API.Helper.DI;
using VMS.API.Helper.Middlewares;
using VMS.BUSINESS.Helpers.Validator.WorkTypeValidator;

namespace VMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<WorkTypeCreateValidator>();
            });
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();
            builder.Services.Resolve();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                      policy =>
                                      {
                                          policy.AllowAnyOrigin()
                                                 .AllowAnyHeader()
                                                 .AllowAnyMethod()
                                                 .SetIsOriginAllowed(x => true);
                                      });
            });


            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("CorsPolicy");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();


        }
    }
}
