﻿
using System;
using System.Net.Http;
namespace front.APIHelper
{
   
        public class APIHelper
        {
            // public static HttpClient ApiClient { get; set; }

            public HttpClient initial()
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7289/");
                // ApiClient.DefaultRequestHeaders.Accept.Clear();
                // ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }
        }
    
}
