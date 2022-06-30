using System;
using MEC;
using Qurre;
using Qurre.API;
using Qurre.API.Objects;
using Qurre.API.Events;
using UnityEngine;
using Qurre.API.Controllers;

namespace CoinFlip
{
    public class CoinFlip : Plugin
    {
        public override string Developer => "KoT0XleB#4663";
        public override string Name => "CoinFlip";
        public override Version Version => new Version(2, 1, 0);
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
            if (CustomConfig.TeleportEnable) Qurre.Events.Player.PickupItem += OnCoinPickup;
        }
        public void UnregisterEvents()
        {
            CustomConfigs.Remove(CustomConfig);
            if (!CustomConfig.IsEnable) return;

            Qurre.Events.Player.CoinFlip -= OnCoinFlip;
            if (CustomConfig.TeleportEnable) Qurre.Events.Player.PickupItem -= OnCoinPickup;
        }
        public void OnCoinFlip(CoinFlipEvent ev)
        {
            Timing.CallDelayed(CustomConfig.Delay, () =>
            {
                if (CustomConfig.TeleportEnable)
                {
                    var roomNumber = UnityEngine.Random.Range(1, 50);
                    if (ev.Player.ItemTypeInHand == ItemType.Coin)
                    {
                        if (Alpha.Detonated == false)
                        {
                            // bugs-dangerous rooms 12 42 48 49
                            if (roomNumber == 12) ev.Player.TeleportToDoor(DoorType.Nuke_Armory);
                            else if (roomNumber == 42) ev.Player.TeleportToDoor(DoorType.HCZ_049_Gate);
                            else if (roomNumber == 48) ev.Player.TeleportToDoor(DoorType.HID);
                            else if (roomNumber == 49)
                            {
                                ev.Player.TeleportToDoor(DoorType.Surface_Nuke);
                                ev.Player.ShowHint(CustomConfig.LuckyMessage, 5);
                            }
                            else ev.Player.Position = Extensions.GetRoom((RoomType)roomNumber).Position + Vector3.up * 2;
                        }
                        else
                        {
                            switch (UnityEngine.Random.Range(1, 4))
                            {
                                case 1: ev.Player.Position = new Vector3(182.57f, 993.91f, -85.54f); break;
                                case 2: ev.Player.Position = new Vector3(40.51f, 988.68f, -35.23f); break;
                                case 3: ev.Player.Position = new Vector3(-10.9f, 1001.15f, -21.17f); break;
                            }
                        }
                        ev.Player.RemoveItem(ev.Player.ItemInHand);
                        ev.Player.ClearBroadcasts();
                        ev.Player.Broadcast(CustomConfig.CoinTeleportMessage, 3);
                    }
                }
                if (CustomConfig.FlipMessageEnable)
                {
                    if (ev.Tails == true) ev.Player.ShowHint(CustomConfig.Result + CustomConfig.FirstCoin, CustomConfig.DelayBroadcast);
                    else ev.Player.ShowHint(CustomConfig.Result + CustomConfig.SecondCoin, CustomConfig.DelayBroadcast);
                }
            });
        }
        public void OnCoinPickup(PickupItemEvent ev)
        {
            if (ev.Pickup.Type == ItemType.Coin)
            {
                ev.Player.ClearBroadcasts();
                ev.Player.Broadcast(CustomConfig.PickupCoinTeleport, 5);
            }
        }
    }
}
