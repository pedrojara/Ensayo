namespace Ensayo.Models
{
    using Newtonsoft.Json;
    class Currency
    {
        [JsonProperty(PropertyName = "code")]//Esta mapeo como esta en java
        public string Code { get; set; }//Se mapea en Mayuscula a el estandar de C#
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
    }
}
