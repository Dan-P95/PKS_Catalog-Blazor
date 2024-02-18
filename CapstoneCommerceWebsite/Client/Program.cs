global using PKS_Catalog.Shared;
global using System.Net.Http.Json;
global using PKS_Catalog.Client.Services.ItemService;
global using PKS_Catalog.Client.Services.GroupService;
global using PKS_Catalog.Client.Services.UserService;
global using PKS_Catalog.Shared;
global using MudBlazor.Services;
global using Blazored.LocalStorage;
global using Microsoft.AspNetCore.Components.Authorization;

using PKS_Catalog.Client;
using PKS_Catalog.Client.Services.UserService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDialogService, DialogService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
