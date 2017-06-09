using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web;
using Windows.Web.Http;
using Windows.Data.Json;
using System;

namespace ProjekatOoad.Services
{
    class FourSquare
    {
        //String u kojem ce se cuvati dobiveni token kako bi se mogao koristiti za Rest pozive
    private string OAuthToken = "";
        public async void authenticate()
        {
            try
            {
                //id koji se dobio od foursqare api pri registraciji
                String clientId = "KHAWRYD4PJ0LKVSZQF4CEXTX5GK3BDPTWS3XLCTVAYQPK515";
                //url za poziv na api koji trazi code string
                String foursqareApiUrl =
               "https://foursquare.com/oauth2/authenticate?client_id=" + clientId +
               "&response_type=code&redirect_uri=https://www.google.ba/";
                System.Uri StartUri = new Uri(foursqareApiUrl);
                //poziv autentikacije koristeci definisani url
                WebAuthenticationResult WebAuthenticationResult = await
               WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, StartUri,
               new Uri("https://www.google.ba/"));
                if (WebAuthenticationResult.ResponseStatus ==
               WebAuthenticationStatus.Success)
                {
                    //ako je sve ok iskoristiti dobiveni code za novi poziv koji trazi OAuthToken
                await getOauthToken(WebAuthenticationResult.ResponseData.ToString());
                }
                else if (WebAuthenticationResult.ResponseStatus ==
               WebAuthenticationStatus.ErrorHttp)
                {
                 
                throw new Exception("HTTP Error returned by AuthenticateAsync() : " + WebAuthenticationResult.ResponseErrorDetail.ToString());
                }
                else
                {
                    throw new Exception("Error returned by AuthenticateAsync() : " +
                   WebAuthenticationResult.ResponseStatus.ToString());
                }
            }
            catch (Exception Error)
            {
                //u slucaju svih ostalih izuzetaka proslijediti dalje
                throw Error;
            }
        }

        private async Task getOauthToken(string webAuthResultResponseData)
        {
            //izdvajanje code parametra iz dobivenog stringa
            string responseData =
           webAuthResultResponseData.Substring(webAuthResultResponseData.IndexOf("code"));
            String[] keyValPairs = responseData.Split('&');
            string code = null;
            for (int i = 0; i < keyValPairs.Length; i++)
            {
                String[] splits = keyValPairs[i].Split('=');
                if (splits[0].Equals("code"))
                {
                    code = splits[1];
                }
            }
            //Koristenje code za dobivanje acess tokena pozivom
            HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(new
           Uri("https://foursquare.com/oauth2/access_token?client_id=" +
           "KHAWRYD4PJ0LKVSZQF4CEXTX5GK3BDPTWS3XLCTVAYQPK515" + "&client_secret=" +
           "BSTBTSNVENYHWGGNYGGQ00X33NJNNFTPZVIPOB3LGC1UVXBI" +
           "&grant_type=authorization_code&redirect_uri=https://www.google.ba/&code=" + code));
            JsonObject value = JsonValue.Parse(response).GetObject();
            OAuthToken = value.GetNamedString("access_token");
        }
        //koristenje OAuthTokena da se dobije json response koji sadrzi sve venus
        public async void getVenus()
        {
            HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(new
           Uri("https://api.foursquare.com/v2/venues/search?ll=40.7,-74&oauth_token=" +
           OAuthToken + "&v=20160410"));
            JsonObject value = JsonValue.Parse(response).GetObject();
            value.GetNamedString("venus");
        }
    }
}