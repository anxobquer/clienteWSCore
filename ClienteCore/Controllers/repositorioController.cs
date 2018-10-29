using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClienteCore.Models;

namespace ClienteCore.Controllers
{
    public class repositorioController : Controller
    {
        private string BASE_URL = "https://app.univo.edu.sv/repositorio/";
        private string BASE_URL_LOGIN_WS = "https://app.univo.edu.sv/auth/";
        //private string BASE_URL = "http://localhost:45653/repositorio/";
        //private string BASE_URL_LOGIN_WS = "http://localhost:45653/auth/";

        private WebClient wc;
        private ResponseToken responseToken;

        private string CARNET_DEMO = "u20140985";

        // GET: repositorio
        public ActionResult Index()
        {
            WebClient wc = new WebClient();
            var res = wc.DownloadString(new Uri(BASE_URL + "GetPlanes/" + CARNET_DEMO));

            ModPlanes[] data = JsonConvert.DeserializeObject<ModPlanes[]>(res);

            return View(data);
        }

        private string token = "";
       
        // GET: repositorio/Create
        public ActionResult Create(LoginModel login)
        {
            /// Parámetros de autenticación
            if (login.UserName == null)
            {
                login = new LoginModel()
                {
                    UserName = "appAlumnos",
                    PassWord = "S@t0sh1_Log9n246"
                };
            }

            /// obtner el token
            try
            {
                wc = new WebClient();
                string json = JsonConvert.SerializeObject(login);

                wc.Headers.Add("Content-Type", "application/json");

                token = JsonConvert.DeserializeObject( wc.UploadString(new Uri(BASE_URL_LOGIN_WS + "LoginWS"), json)).ToString();

                responseToken = JsonConvert.DeserializeObject<ResponseToken>( token );
            }
            catch (Exception e)
            {
                throw e;
            }

            /// Obtener datos del WS que solicita token válido
            using ( WebClient webClient = new WebClient() ) {
                webClient.Headers.Add( "Content-Type" , "application/json" );
                webClient.Headers[ HttpRequestHeader.Authorization ] = "Bearer " + responseToken.AccessToken;
                string data = webClient.DownloadString(BASE_URL + "GetRecord/" + CARNET_DEMO);
                return View(data);
            }
        }
    }
}