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
    class SpamDeadBody : Module
    {
        public SpamDeadBody() : base("Spam Dead Body Local", "yipiie",ModuleType.Button)
        {

        }

        public override void OnEnable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            // LOCAL
            player.SpawnDeadBody((int)player.playerClientId, new Vector3(0, 0, 0), 0, player, 0, player.playerRigidbody.transform);

        }

    }
}
