using System.Threading.Tasks;

namespace shortLinkApp.Services {
    public interface IShortenURLService
    {
        public Task<string> shortenUrl(string url);
    }
}