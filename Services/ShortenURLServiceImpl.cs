using System.Threading.Tasks;
using BitlyAPI;
using Microsoft.Extensions.Configuration;

namespace shortLinkApp.Services {
    
    public class ShortenURLServiceImpl : IShortenURLService
    {
        private readonly IConfiguration _configuration;
        private string _token;

        public ShortenURLServiceImpl(IConfiguration configuration) {
            _configuration = configuration;
            _token = _configuration.GetValue<string>("bitlyToken");;
        }

        public async Task<string> shortenUrl(string url) {
            var bitly = new Bitly(_token);
            var linkResponse = await bitly.PostShorten(url);
            var newLink = linkResponse.Link;
            return newLink;
        }
    }
}