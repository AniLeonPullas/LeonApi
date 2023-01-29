using System.Net;
using LeonApi.Models;
using Newtonsoft.Json;
namespace LeonApi;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    public async void Button_Clicked(object sender, EventArgs e)
    {
        string cadena = Buscador.Text;
        var request = new HttpRequestMessage();
        //request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts?userId=" + cadena);
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json"); var client = new HttpClient(); HttpResponseMessage response = await client.SendAsync(request);
        
        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Post>>(content);
            ListaDemo.ItemsSource = resultado;
        }
    }
}

