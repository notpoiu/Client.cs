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
    class KillSelf : Module
    {
        public KillSelf() : base("Kill Self", "kills yourself",ModuleType.Button)
        {

        }

        public override void OnEnable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            player.KillPlayer(new Vector3(0, 0, 0), true, CauseOfDeath.Unknown, 0);
        }

    }
}
