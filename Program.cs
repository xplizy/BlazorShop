using BlazorShop.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using BlazorShop.Models;
using BlazorShop.DataAccessLayer;
using MongoDB.Bson;
using MongoDB.Driver;
using BlazorShop.Interface;
using BlazorShop.Controller;

namespace BlazorShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddScoped<IProductApiClient, ProductApiClient>(); // Use AddScoped
            builder.Services.AddHttpClient(); // Add HttpClient service to the container
            builder.Services.AddScoped<ProductAccessLayer>();
            builder.Services.AddScoped<IProducts, ProductAccessLayer>();
            builder.Services.AddScoped<ICartService, CartService>();
            var app = builder.Build();

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
            app.MapDefaultControllerRoute();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}