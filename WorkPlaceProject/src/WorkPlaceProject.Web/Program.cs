using Microsoft.AspNetCore.ResponseCompression;
using WorkPlaceProject.Web.Hubs;
using WorkPlaceProject.Application.Weather;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.HttpOverrides;
using StackExchange.Redis;
using WorkPlaceProject.Persistence.StoryPointer;
using WorkPlaceProject.Application.StoryPointer;
using WorkPlaceProject.Domain.StoryPointer;
using WorkPlaceProject.Persistence.StoryPointerSession;
using WorkPlaceProject.Application.StoryPointerSession;
using WorkPlaceProject.Domain.StoryPointerSession;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
            .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost;
});

// Add services to the container.
builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

builder.Services.AddSingleton<WeatherForecastApplicationService>();

builder.Services.AddScoped<IStoryPointSelectionApplicationService, StoryPointSelectionApplicationService>();
builder.Services.AddScoped<IStoryPointSelectionDomainService, StoryPointSelectionDomainService>();
builder.Services.AddScoped<IStoryPointSelectionRepository, StoryPointSelectionRepository>();

builder.Services.AddScoped<IPointerSessionApplicationService, PointerSessionApplicationService>();
builder.Services.AddScoped<IPointerSessionDomainService, PointerSessionDomainService>();
builder.Services.AddScoped<IPointerSessionRepository, PointerSessionRepository>();

builder.Services.AddSingleton<IConnectionMultiplexer>(options => 
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")));

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseResponseCompression();

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

app.MapControllers();

app.MapBlazorHub();
app.MapHub<StoryPointerHub>("/storypointerhub");
app.MapFallbackToPage("/_Host");

app.Run();
