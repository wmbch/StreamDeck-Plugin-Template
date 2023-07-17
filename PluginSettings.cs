using BarRaider.SdTools;
using Newtonsoft.Json;

namespace StreamDeckPluginTemplate
{
    internal class PluginSettings
    {
        [FilenameProperty]
        [JsonProperty(PropertyName = "outputFileName")]
        public string OutputFileName { get; set; }

        [JsonProperty(PropertyName = "inputString")]
        public string InputString { get; set; }
    }
}
