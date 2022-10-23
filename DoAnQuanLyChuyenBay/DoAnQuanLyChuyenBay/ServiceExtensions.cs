using DoAnCB.DataAccess;
using DoAnCB.Entity;
using DoAnCB.Services;
using DoAnCB.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCB.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                //.AddUserStore<UserStore>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
            });
        }
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("Jwt").Get<JwtTokenSetting>();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
#if DEBUG
                    cfg.RequireHttpsMetadata = false;
#endif
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = config.Issuer,
                        ValidAudience = config.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // User Services
            services.AddScoped<IUserServices, UserServices>();

            services.AddScoped<ISanBayDiServices, SanBayDiServices>();
            services.AddScoped<ISanBayDenServices, SanBayDenServices>();
            services.AddScoped<IMayBayServices, MayBayServices>();
            services.AddScoped<IChuyenBayServices, ChuyenBayServices>();
            services.AddScoped<IDatChoHanhKhachServices, DatChoHanhKhachServices>();
            //services.AddScoped<IKhachHangServices, KhachHangServices>();
        }
    }
}
