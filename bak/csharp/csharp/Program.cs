using csharp.Repository;
using csharp.Services.Authorization;
using ikvm.runtime;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using sun.security.x509;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var DBConnection = "TreinamentoCSharp";
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddCors();
builder.Services.AddControllers();
TokenService.secretKey = builder.Configuration.GetSection("JWT_Secret").Value;

byte[] key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JWT_Secret").Value);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
}


);




builder.Services.AddEndpointsApiExplorer();
BaseRepository.DBConnection = builder.Configuration.GetConnectionString(DBConnection);

var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
);



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapRazorPages();

app.Run();

