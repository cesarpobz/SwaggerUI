using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodingAssignment.Models;
using CodingAssignment.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace CodingAssignment.Services
{
    public class FileManagerService: IFileManagerService
    {
        private string jsonFile = @"./AppData/DataFile.json";
        public DataFileModel GetData()
        {
            var data = JsonConvert.DeserializeObject<DataFileModel>(File.ReadAllText(jsonFile));

            return data;
        }

        public bool Insert(DataModel model)
        {
            var newItem = "{ 'Id': " + model.Id + ",'Name': '" + model.Name + "'}";
            var json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            var dataArray = jsonObj.GetValue("Data") as JArray;
            var newData = JObject.Parse(newItem);
            dataArray.Add(newData);
            jsonObj["Data"] = dataArray;
            string newJsonResult = JsonConvert.SerializeObject(jsonObj,
                            Formatting.Indented);
            File.WriteAllText(jsonFile, newJsonResult);
            return true;
        }

        public bool Update(DataModel model, int id)
        {
            var json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            JArray dataArrary = (JArray)jsonObj["Data"];
            foreach (var data in dataArrary.Where(obj => obj["Id"].Value<int>() == id))
            {
                data["Name"] = !string.IsNullOrEmpty(model.Name) ? model.Name : "";
            }
            jsonObj["Data"] = dataArrary;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(jsonFile, output);
            return true;
        }

        public bool Delete(int id)
        {
            var json = File.ReadAllText(jsonFile);
            var jsonObj = JObject.Parse(json);
            JArray dataArrary = (JArray)jsonObj["Data"];
            var nameToDelete = dataArrary.FirstOrDefault(obj => obj["Id"].Value<int>() == id);
            dataArrary.Remove(nameToDelete);
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(jsonFile, output);
            return true;
        }
    }
}
