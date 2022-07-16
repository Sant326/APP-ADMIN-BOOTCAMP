using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WebApiAutores.Repositories;
using WebApiAutores.Services;


namespace WebApiAutores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)//constructor
        {

            Configuration = configuration;

        }

       // private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services )
        {

            services.AddScoped<ItokenService, TokenService>();
            services.AddTransient<UserRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();

            services.AddTransient<UserService>();
            services.AddTransient<ICourseService , CourseService>();

            services.AddControllers().AddJsonOptions(x => 
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
          
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           
           
           
            //services.AddTransient<IUserService, UserService>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
                
            });
            /*
            var str = ConfigurationHandler.GetSection<string>(StringConstants.AppSettingsKeys.CORSWhitelistedURL);
            if (!string.IsNullOrEmpty(str))
            {
                services.AddCors(options =>
                {
                    options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(str);
                    });
                });
            }
            */

        }

        public void  Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors();
            app.UseAuthorization();
            app.UseAuthentication();   

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });


        }

    }
}
