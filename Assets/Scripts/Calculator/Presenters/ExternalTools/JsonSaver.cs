using Calculator.Models;
using Core.Presenters.ExternalTools;
using UnityEngine;

namespace Calculator.Presenters.ExternalTools
{
    public class JsonSaver : DataSaver<BaseCalculatorData>
    {
        private readonly string key;

        
        public JsonSaver(string key)
        {
            this.key = key;
        }

        
        public override void Save(BaseCalculatorData data)
        {
            string json = JsonUtility.ToJson(data);

            SaveDataToPermanentMemory(json);
        }

        
        private void SaveDataToPermanentMemory(string data)
        {
            PlayerPrefs.SetString(key, data);
        }
        

        public override BaseCalculatorData Load()
        {
            return JsonUtility.FromJson<BaseCalculatorData>(LoadDataFromPermanentMemory());
        }

        
        private string LoadDataFromPermanentMemory()
        {
            return PlayerPrefs.GetString(key, JsonUtility.ToJson(BaseCalculatorData.Empty));
        }
    }
}