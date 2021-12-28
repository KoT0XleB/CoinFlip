using System;
using Qurre;
using MEC;
using Qurre.API.Events;

namespace CoinFlip
{
    public class CoinFlip : Plugin
    {
        public override string Developer => "KoToXleB#4663";
        public override string Name => "CoinFlip";
        public override Version Version => new Version(1, 0, 0);
        public override int Priority => int.MinValue;
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        public static Config CustomConfig { get; private set; }
        public void RegisterEvents()
        {
            CustomConfig = new Config();
            CustomConfigs.Add(CustomConfig);
            if (!CustomConfig.IsEnable) return;

            Qurre.Events.Player.CoinFlip += OnCoinFlip;
        }
        public void UnregisterEvents()
        {
            CustomConfigs.Remove(CustomConfig);
            if (!CustomConfig.IsEnable) return;

            Qurre.Events.Player.CoinFlip -= OnCoinFlip;
        }
        public static void OnCoinFlip(CoinFlipEvent ev)
        {
            Timing.CallDelayed(CustomConfig.Delay, () =>
            {
                if (UnityEngine.Random.Range(0, 2) == 0) ev.Player.ShowHint($"{CustomConfig.Result}: {CustomConfig.FirstCoin}", CustomConfig.DelayBroadcast);
                else ev.Player.ShowHint($"{CustomConfig.Result}: {CustomConfig.SecondCoin}", CustomConfig.DelayBroadcast);
            });
        }
    }
}
