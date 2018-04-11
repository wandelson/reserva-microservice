using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Unidas.Servicos;
using Xunit;

namespace Unidas.CentralDeReservas.Api.IntegrationTest
{
    public class ReservaTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private const string url = "/api/v1/reservas";


        public ReservaTest()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task Reserva_Salvar_Com_Sucesso()
        {
            var command = new CriarReservaCommand
            {
                Acordo = 1,
                CanalVenda = 1,
                NomeCondutor = "Wandelson",
                Tarifa = 2
            };

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var root = JsonConvert.DeserializeObject<CriarReservaResult>(await response.Content.ReadAsStringAsync());

           /* var output = JsonConvert.DeserializeObject<Entity>(root.data.ToString());

            Assert.Equal(output.FullName, person.FullName);


            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!",
                responseString);*/
        }
    }
}
