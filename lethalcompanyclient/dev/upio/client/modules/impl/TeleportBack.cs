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
    class TeleportBack : Module
    {
        public TeleportBack() : base("Back to ship", "teleports back",ModuleType.Button)
        {

        }

        public override void OnEnable()
        {
            PlayerControllerB player = HUDManager.Instance.localPlayer;

            if (player == null)
                return;

            //player.TeleportPlayer(StartOfRound.Instance.elevatorTransform.position);
            player.TeleportPlayer(StartOfRound.Instance.playerSpawnPositions[(int)(checked((IntPtr)player.playerClientId))].position);
        }

    }
}
