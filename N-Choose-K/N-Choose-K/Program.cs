using System;

namespace NChooseK
{
    public class Program
    {
        static int numberOfPossibleCombinations( int n, int k )
        {
            if ( k == 0 || k == n )
            {
                return 1;
            }
            else
            {
                return numberOfPossibleCombinations(n - 1, k) + numberOfPossibleCombinations( n - 1, k - 1 );
            }
        }
    }
    
    public static void Main(string[] args)
    {
        System.Diagnostics.Debug.WriteLine(numberOfPossibleCombinations(3, 2));
    }

}

// var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
builder.Services.AddControllersWithViews();

var app = builder.Build();
*/

// Configure the HTTP request pipeline.
/*
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
*/
/*
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
*/