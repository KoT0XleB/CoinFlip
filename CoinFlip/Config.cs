using Qurre.API.Addons;
using System.ComponentModel;

namespace CoinFlip
{
    public class Config : IConfig
    {
        [Description("Plugin Name")]
        public string Name { get; set; } = "CoinFlip";

        [Description("Enable the plugin?")]
        public bool IsEnable { get; set; } = true;
        [Description("Just result string")]
        public string Result { get; set; } = "Result ";
        [Description("The name of the first side of the coin? Tail or Решка")]
        public string FirstCoin { get; set; } = "Tail";
        [Description("The name of the second side of the coin? Head or Орел")]
        public string SecondCoin { get; set; } = "Head";
        [Description("Delay before showing broadcast")]
        public float Delay { get; set; } = 1.5f;
        [Description("How long should the broadcast show?")]
        public float DelayBroadcast { get; set; } = 3f;
    }
}
