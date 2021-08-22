using System;
using System.IO;
using Newtonsoft.Json;

namespace task2.app.Services
{
    public class JsonMapper
    {
        public string fileName { get; set; }

        public JsonMapper(string name) {
            fileName = name;
        }

        public T Deserialize<T>(T entity){
            //get json file as filestream
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+fileName))
            {
                string json = r.ReadToEnd();
                var type = entity.GetType();
                //Deserialize hoterates.json into T class
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}