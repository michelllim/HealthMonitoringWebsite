using HealthMonitoringWebsite.Client;
using HealthMonitoringWebsite.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Toolbelt.Blazor.Extensions.DependencyInjection;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("CarRentalManagement.ServerAPI", (sp, client) => {
	client.BaseAddress = new
	Uri(builder.HostEnvironment.BaseAddress);
	client.EnableIntercept(sp);
})
.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CarRentalManagement.ServerAPI"));

builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();

builder.Services.AddApiAuthorization();

//builder.Services.AddAuthorizationCore(options =>
//{
//	options.AddPolicy("AdminPolicy", policy =>
//		policy.RequireRole("Admin"));

//	options.AddPolicy("StaffPolicy", policy =>
//		policy.RequireRole("Staff"));

//	options.AddPolicy("UserPolicy", policy =>
//		policy.RequireRole("User"));
//});

await builder.Build().RunAsync();
