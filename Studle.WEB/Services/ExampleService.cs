using Studle.WEB.Interfaces;

namespace Studle.WEB.Services
{
    public class ExampleService : IExampleService
    {
        public string GetHelloWord()
        {
            return "Hello World";
        }
    }
}