using System;
using CardServer.Util;

namespace CardServer.Networking
{
    public class GameMessage
    {
        public int SequenceId { get; set; }
        public string SerializedJson { get; set; }
        public Type ContentType { get; set; }

        public GameMessage(Object obj)
        {
            string json = Util.Json.Serialize(obj);

            this.SerializedJson = json;

            this.ContentType = obj.GetType();

            Debug.Log($"Crafted JSON message:\n{json}");
        }

        public GameMessage() { }

        public T DeserializeContent<T>()
        {
            // return JsonConvert.DeserializeObject<T>(this.SerializedJson);
            return Util.Json.Deserialize<T>(this.SerializedJson);
        }
    }
}