﻿using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TableContainerFrontEnd.Classes
{
    public static class JsonConvertEx
    {
        /// <summary>
        /// Serialize T with options
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(T value)
        {
            StringBuilder sb = new();
            
            var sw = new StringWriter(sb, CultureInfo.InvariantCulture);

            var jsonSerializer = JsonSerializer.CreateDefault();

            using var jsonWriter = new JsonTextWriter(sw)
            {
                Formatting = Formatting.Indented, 
                IndentChar = ' ', 
                Indentation = 4
            };

            jsonSerializer.Serialize(jsonWriter, value, typeof(T));

            return sw.ToString();
        }
    }
}