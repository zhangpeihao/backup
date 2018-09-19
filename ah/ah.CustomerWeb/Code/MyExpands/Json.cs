﻿using ah.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ah.Code.MyExpands
{
    public static class Json
    {
        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }

        public static List<T> ToNotNullList<T>(this string json) where T : new()
        {
            return (json == null) ? new List<T>(): JsonConvert.DeserializeObject<List<T>>(json);
        }
 


    }


    public static class Expands_Json
    {

        public static dynamic GetValue(this Newtonsoft.Json.Linq.JObject jObj, params string[] keys)
        {
            try
            {
                return Ass.Data.Utils.GetJsonValue(jObj, keys);
            }
            catch { return ""; }
        }
        public static dynamic GetValueString(this Newtonsoft.Json.Linq.JObject jObj, params string[] keys)
        {
            try
            {
                return Ass.P.PStr(Ass.Data.Utils.GetJsonValue(jObj, keys));
            }
            catch { return ""; }
        }
        public static dynamic GetValue(this Newtonsoft.Json.Linq.JToken jObj, params string[] keys)
        {
            try
            {
                return Ass.Data.Utils.GetJsonValue(jObj, keys);
            }
            catch { return ""; }
        }

        public static dynamic GetValueString(this Newtonsoft.Json.Linq.JToken jObj, params string[] keys)
        {
            try
            {
                return Ass.P.PStr(Ass.Data.Utils.GetJsonValue(jObj, keys));
            }
            catch { return ""; }
        }

    }


}