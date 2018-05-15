namespace Ensayo.Models
{
    using Newtonsoft.Json;
    public class Translations
    {
        [JsonProperty(PropertyName = "de")]//Esta mapeo como esta en java
        public string Germany { get; set; }
        [JsonProperty(PropertyName = "es")]
        public string Spanish { get; set; }
        [JsonProperty(PropertyName = "fr")]
        public string French { get; set; }
        [JsonProperty(PropertyName = "ja")]
        public string Japan  { get; set; }
        [JsonProperty(PropertyName = "it")]
        public string Italian { get; set; }
        [JsonProperty(PropertyName = "br")]
        public string Brazilian { get; set; }
        [JsonProperty(PropertyName = "pt")]
        public string Portugues { get; set; }
        [JsonProperty(PropertyName = "nl")]
        public string Dutch { get; set; }
        [JsonProperty(PropertyName = "hr")]
        public string Croatian { get; set; }
        [JsonProperty(PropertyName = "fa")]
        public string Danish { get; set; }
    }
}
