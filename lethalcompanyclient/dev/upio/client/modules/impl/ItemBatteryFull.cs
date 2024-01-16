using client.dev.upio.client;
using client.dev.upio.client.Modules;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace client.dev.upio.client.modules.impl
{
    class ItemBatteryFull : Module
    {
        public ItemBatteryFull() : base("Infinite Battery", "ez",ModuleType.Toggle)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            if (player.currentlyHeldObjectServer == null)
                return;

            GrabbableObject obj = player.currentlyHeldObjectServer;

            if (obj.itemProperties.requiresBattery)
            {
                obj.SyncBatteryServerRpc(100);
            }
        }

    }
}
