namespace Ensayo.Models
{
    using Newtonsoft.Json;
    public class RegionalBloc
    {
        [JsonProperty(PropertyName = "acronym")]//Esta mapeo como esta en java
        public string Acronym { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
