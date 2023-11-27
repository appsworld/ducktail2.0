using System.Net.Http;
using iCollector.Function.CURL.Model;

namespace iCollector.RestClient;

internal interface IRestClient
{
	CurlResponse<string> Get(string url, string[] headers);

	CurlResponse<string> Post(string url, string body, string[] headers);

	CurlResponse<string> PostMultipartForm(string url, MultipartFormDataContent body, string[] headers);
}
