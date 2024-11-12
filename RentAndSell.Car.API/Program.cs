using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API.Data;
using System.Text;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CarRentDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CarRentConn")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

//GET | POST | PUT | PATCH | DELETE | OPTIONS


#region Senkron main metod
//app.Map("/",  () =>
//{

//    return "Hello World All Methods GET | POST | PUT | PATCH | DELETE | OPTIONS";

//}); 
#endregion

#region Asenkron with context method
//app.Map("/", async (context) =>
//{
//    await context.Response.WriteAsync("Hello World All Methods GET | POST | PUT | PATCH | DELETE | OPTIONS\n");

//    if (context.Request.Method == HttpMethod.Get.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only GET ");
//    if (context.Request.Method == HttpMethod.Post.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only POST");
//    if (context.Request.Method == HttpMethod.Put.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only PUT");
//    if (context.Request.Method == HttpMethod.Patch.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only PATCH");
//    if (context.Request.Method == HttpMethod.Delete.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only DELETE");
//    if (context.Request.Method == HttpMethod.Options.ToString().ToUpper(new System.Globalization.CultureInfo("en-Us"))) ;
//    await context.Response.WriteAsync("Hello World Only OPTIONS");

//});
#endregion

#region Http All Verbs Endpoint Map Get | Post | Put | Patch | Delete
//app.MapGet("/", () =>
//{
//return "Hello World Only GET";
//});

//app.MapPost("/", () =>
//{
//    return "Hello World Only POST";
//});

//app.MapPut("/", () =>
//{
//    return "Hello World Only PUT";
//});

//app.MapPatch("/", () =>
//{
//    return "Hello World Only PATCH";
//});

//app.MapDelete("/", () =>
//{
//    return "Hello World Only DELETE";
//}); 
#endregion

#region content-type özelinde örnekler text/plain text/css text/html

app.Map("/", async (context) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.Headers.Accept = "Accept Info";
        context.Response.Headers.AcceptCharset = "UTF-8";
        context.Response.Headers.AcceptLanguage = "tr-TR";
        context.Response.Headers.AccessControlAllowOrigin = "*";
        context.Response.Headers.AccessControlAllowMethods = "GET, POST, PUT";

    }
    //return "Text Plain";
    //context.Response.StatusCode = 404;

});

//app.MapGet("/", async (context) =>
//{
//    if (context.Request.Headers.UserAgent.ToString().Contains("Postman"))
//    {
//        context.Response.StatusCode = 404;
//    }
//    else
//    {
//        string responseContent = "Herhangi bir þey <b>bold</b>";
//        context.Response.StatusCode = 200;
//        context.Response.ContentLength = Encoding.UTF8.GetByteCount(responseContent); /*responseContent.Length;*/
//        context.Response.ContentType = "text/html ; charset=utf-8";



//        await context.Response.WriteAsync(responseContent);
//    }
//});
app.MapGet("/{cssFileName}", async (HttpContext context, string cssFileName) =>
{
    string cssContent = "";

    switch (cssFileName)
    {
        case "user.css":
            cssContent = @"p { color: red; font-size: 8px }";
            break;
        case "main.css":
            cssContent = @"p { color: blue; font-size: 24px }";
            break;
        case "index.css":
            cssContent = @"p { color: yellow; font-size: 48px }";
            break;
    }

    context.Response.StatusCode = 200;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(cssContent);
    context.Response.ContentType = "text/css; charset=utf-8";

    await context.Response.WriteAsync(cssContent);

}); 
#endregion

#region Car CRUD Operations

//List<Car> cars = new List<Car>();

////GET      htps://localhost:7027/Cars              => AllCars

//app.MapGet("/Cars", () =>
//{
//    return cars;
//});

////GET      htps://localhost:7027/Cars/{id}         => Car With id

//app.MapGet("/Cars/{id}", (int id) =>
//{
//    return cars.Where(c => c.Id == id).SingleOrDefault();
//});


////POST     htps://localhost:7027/Cars              => JsonData Model ile New Car

//app.MapPost("/Cars", (Car car) =>
//{
//    //int lastId = cars.MaxBy(c => c.Id).Id;

//    //car.Id = lastId + 1;

//    cars.Add(car);
//    return car;
//});

////PUT      htps://localhost:7027/Cars/{id}         => JsonData Model ve id ile Edit Car

//app.MapPut("/Cars/{id}", (int id, Car car) =>
//{
//    Car findOriginalCar = cars.Where(c => c.Id == id).SingleOrDefault();
//    int findOriginalIndex = cars.IndexOf(findOriginalCar);


//    cars[findOriginalIndex] = car;

//    return car;
//});

////DELETE   htps://localhost:7027/Cars/{id}         => Car id ile Delete Car

//app.MapDelete("/Cars/{id}", (int id) =>
//{
//    Car removedCar = cars.Where(c => c.Id == id).SingleOrDefault();

//    cars.Remove(removedCar);

//    return removedCar;
//});
#endregion

app.Run();
