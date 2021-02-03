using DynamicFieldsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            catch (Exception e)
            { 
                throw new Exception("Произошла ошибка при обработке JSON", e); 
            }
            return fields;
        }
        public async static Task<List<Field>> GetFieldsFromJsonAsync(string json)
        {
            return await Task.Run(() => GetFieldsFromJson(json));
        }
    }
}
