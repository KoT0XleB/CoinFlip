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
        [Description("Enable the ability to teleport when flip a coin?")]
        public bool TeleportEnable { get; set; } = true;
        [Description("Enable the coin-side text?")]
        public bool FlipMessageEnable { get; set; } = true;
        [Description("Just result string. Result: ")]
        public string Result { get; set; } = "Результат: ";
        [Description("The name of the first side of the coin? Tail or Решка")]
        public string FirstCoin { get; set; } = "Решка";
        [Description("The name of the second side of the coin? Head or Орел")]
        public string SecondCoin { get; set; } = "Орел";
        [Description("A message when a player is lucky enough to be on the street while teleporting.")]
        public string LuckyMessage { get; set; } = "<color=green><b>Чувак</b>, тебе повезло!</color>";
        [Description("A message when a person was teleported by a coin.")]
        public string CoinTeleportMessage { get; set; } = "<color=red>Вас телепортировала <color=cyan>монетка!</color></color>";
        [Description("A message when a person picks up a coin.")]
        public string PickupCoinTeleport { get; set; } = "<color=yellow>Вы подобрали <color=#77DD77>Монетку Телепортации.</color>\n Подкиньте монетку, чтобы <color=#990066>телепортироваться.</color></color>";
        [Description("Delay before showing broadcast")]
        public float Delay { get; set; } = 1.5f;
        [Description("How long should the broadcast show?")]
        public float DelayBroadcast { get; set; } = 3f;
    }
}
