using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
	public class TripLogApiDataService : BaseHttpService, ITripLogDataService
	{
		readonly Uri _baseUri;
		readonly IDictionary<string, string> _headers;

		struct IdProviderToken
		{
			[JsonProperty("access_token")]
			public string AccessToken { get; set; }
		}

		public TripLogApiDataService(Uri baseUri, string authToken)
		{
			_baseUri = baseUri;
			_headers = new Dictionary<string, string>();
			
			_headers.Add("zumo-api-version", "2.0.0");
			_headers.Add("x-zumo-auth", authToken);
		}

		public async Task<TripLogApiAuthToken> GetAuthTokenAsync(string idProvider, string idProviderToken)
		{
			var token = new IdProviderToken
			{
				AccessToken = idProviderToken
			};

			var url = new Uri(_baseUri, string.Format(".auth/login/{0}", idProvider));
			
			var response = await SendRequestAsync<TripLogApiAuthToken>(url, HttpMethod.Post, _headers, token);
              
			// Update this service with the new auth token
			if (response != null)
			{
				var authToken = response.AuthenticationToken;

				_headers["x-zumo-auth"] = authToken;
			}

			return response;
		}

		public async Task<IList<TripLogEntry>> GetEntriesAsync()
		{
			var url = new Uri(_baseUri, "/tables/entry");
			var response = await SendRequestAsync<TripLogEntry[]>(url, HttpMethod.Get, _headers);

			return response;
		}

		public async Task<TripLogEntry> GetEntryAsync(string id)
		{
			var url = new Uri(_baseUri,	string.Format("/tables/entry/{0}", id));
			var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Get, _headers);

			return response;
		}

		public async Task<TripLogEntry> AddEntryAsync(TripLogEntry entry)
		{
			var url = new Uri(_baseUri, "/tables/entry");
			var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Post, _headers, entry);

			return response;
		}

		public async Task<TripLogEntry> UpdateEntryAsync(TripLogEntry entry)
		{
			var url = new Uri(_baseUri,	string.Format("/tables/entry/{0}", entry.Id));
			var response = await SendRequestAsync<TripLogEntry>(url, new HttpMethod("PATCH"), _headers, entry);

			return response;
		}

		public async Task RemoveEntryAsync(TripLogEntry entry)
		{
			var url = new Uri(_baseUri,	string.Format("/tables/entry/{0}", entry.Id));
			var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Delete, _headers);
		}
	}
}
