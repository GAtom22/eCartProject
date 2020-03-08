﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace UI.Cart2
{
    public class PayPalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PayPalConfiguration()
        {
            var config = getconfig();
            clientId = config["clientId"];
            clientSecret = config["clientSecret"];
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }

    }
}