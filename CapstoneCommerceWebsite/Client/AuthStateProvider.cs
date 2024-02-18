using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace PKS_Catalog.Client
{
	//see microsoft documentation for more details 
	public class AuthStateProvider : AuthenticationStateProvider
	{
		private readonly ILocalStorageService _localStorageService;
		private readonly HttpClient _http;

		public AuthStateProvider(ILocalStorageService localStorageService, HttpClient http)
		{
			_localStorageService = localStorageService;
			_http = http;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			string token = await _localStorageService.GetItemAsStringAsync("authToken");

			var identity = new ClaimsIdentity();
			_http.DefaultRequestHeaders.Authorization = null;

			if (!string.IsNullOrEmpty(token))
			{
				try
				{
					identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
					_http.DefaultRequestHeaders.Authorization =
						new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
				}
				catch
				{
					await _localStorageService.RemoveItemAsync("authToken");
					identity = new ClaimsIdentity();
				}
			}
			var user = new ClaimsPrincipal(identity);
			var state = new AuthenticationState(user);
			NotifyAuthenticationStateChanged(Task.FromResult(state));

			return state;
		}

		private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
		{
			var payload = jwt.Split('.')[1];
			var jsonBytes = ParseBase64WithoutPadding(payload);
			var keyValue = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
			var claims = keyValue.Select(kv => new Claim(kv.Key, kv.Value.ToString()));
			return claims;
		}

		private byte[] ParseBase64WithoutPadding(string base64)
		{
			switch (base64.Length % 4)
			{
				case 2: base64 += "==";
					break;
				case 3: base64 += "=";
					break;
			}
			return Convert.FromBase64String(base64);
		}
	}
}
