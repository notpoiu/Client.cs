using client.dev.upio.client;
using client.dev.upio.client.Modules;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace client.dev.upio.client.modules.impl
{
    class Weightless : Module
    {
        public Weightless() : base("Weightless", "No weight",ModuleType.Toggle)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            player.carryWeight = 1f;
        }
    }
}
