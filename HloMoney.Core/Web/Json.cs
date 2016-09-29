﻿using System.Web.Script.Serialization;

namespace HloMoney.Core.Web
{
    internal class Json
    {
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        internal static T Deserialize<T>(string value)
        {
            return Serializer.Deserialize<T>(value);
        }

        internal static string Serialize(object obj)
        {
            return Serializer.Serialize(obj);
        }
    }
}