using DynamicFieldsApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFieldsApp.Helpers
{
    public static class JsonHelper
    {
        public static List<Field> GetFieldsFromJson(string json)
        {
            List<Field> fields;
            try
            {
                fields = JsonConvert.DeserializeObject<List<Field>>(json);
            }
            catch
            {
                try
                {
                    var parsedJson = JObject.Parse(json);
                    var innerFieldCollection = parsedJson["fields"].Children().ToList();
                    fields = new List<Field>();
                    foreach (var token in innerFieldCollection)
                    {
                        fields.Add(token.ToObject<Field>());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Произошла ошибка при обработке JSON", ex);
                }
            }
            return fields;
        }
        public async static Task<List<Field>> GetFieldsFromJsonAsync(string json)
        {
            return await Task.Run(() => GetFieldsFromJson(json));
        }
    }
}
