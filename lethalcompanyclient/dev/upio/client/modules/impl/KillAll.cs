using client.dev.upio.client;
using client.dev.upio.client.Modules;
using GameNetcodeStuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace client.dev.upio.client.modules.impl
{
    class KillAll : Module
    {
        public KillAll() : base("Kill All", "kill all",ModuleType.Button)
        {

        }

        public override void OnEnable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            for (int i = 0; i < StartOfRound.Instance.allPlayerObjects.Length; i++)
            {
                PlayerControllerB otherPlayer = StartOfRound.Instance.allPlayerObjects[i].GetComponent<PlayerControllerB>();

                if (otherPlayer == player && ModuleManager.godmode.IsEnabled)
                    continue;

                otherPlayer.DamagePlayerFromOtherClientServerRpc(100, new Vector3(0, 0, 0), i + 1);
            }
        }

    }
}
