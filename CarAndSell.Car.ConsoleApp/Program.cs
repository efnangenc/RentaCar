//Http isteği atmak istiyorum kime??
//https://localhost:7027/api/cars/ bu adrese istek atacağız
//nasıl??

using CarAndSell.Car.ConsoleApp.Models;
using System.Collections.Generic;
using System.Net.Http.Json;

HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://localhost:7027/api/");

#region HttpClient istek tipleri
#region response message işlemleri ile yapılan istek
//HttpResponseMessage httpResponseMessage = httpClient.GetAsync("cars").Result;
//HttpContent content = httpResponseMessage.Content;
//var responsecontentJson = content.ReadFromJsonAsync(typeof(List<ArabaViewModel>)).Result;  //bu üçlü blok aşağıda tek satırda yazılabildi

//string responsecontent = content.ReadAsStringAsync().Result;
//var responsecontentJson = content.ReadFromJsonAsync(typeof(List<ArabaViewModel>)).Result;  
//List<ArabaViewModel> arabaViewModelsList = content.ReadFromJsonAsync<List<ArabaViewModel>>().Result;  //işte tekte bu satır
#endregion
#region fromjsonasync return object isteği

//List<ArabaViewModel> arabaViewModel = (List<ArabaViewModel>)httpClient.GetFromJsonAsync("cars",typeof(List<ArabaViewModel>)).Result;

#endregion 
#endregion


List<ArabaViewModel> arabaViewModel = httpClient.GetFromJsonAsync<List<ArabaViewModel>>("cars").Result;  //kullanışlı olan metot // hızlı cevap verir

Console.WriteLine("Araba lsites");

foreach (ArabaViewModel araba in arabaViewModel)
{

    Console.WriteLine($"{araba.Marka} {araba.Model} {araba.Yili}");
}

Console.WriteLine("-------------------Yeni Kayıt----------------------------------");

Console.Write("Marka:");
string marka = Console.ReadLine();
Console.Write("Model:");
string model = Console.ReadLine();
Console.Write("Yili:");
string yili = Console.ReadLine();
Console.Write("Yakıt Tipi:");
string yakitTuru = Console.ReadLine();
Console.Write("Şanzıman Türü:");
string sanzimanTuru = Console.ReadLine();
Console.Write("Motor Tipi:");
string motorTipi = Console.ReadLine();

ArabaViewModel yeniAraba = new ArabaViewModel();
yeniAraba.Marka = marka;
yeniAraba.Model = model;
yeniAraba.Yili = short.Parse(yili);
yeniAraba.YakitTuru = int.Parse(yakitTuru);
yeniAraba.MotorTipi = int.Parse(motorTipi);
yeniAraba.SanzimanTipi = int.Parse(sanzimanTuru);

HttpResponseMessage responsePostMessage = await httpClient.PostAsJsonAsync("Cars", yeniAraba);

if(responsePostMessage.IsSuccessStatusCode)
{
    Console.WriteLine("yeni araba kayıt edildi");
    var responseData = await responsePostMessage.Content.ReadAsStringAsync();

    Console.WriteLine($"yanıt: {responseData}");
}

Console.ReadLine();