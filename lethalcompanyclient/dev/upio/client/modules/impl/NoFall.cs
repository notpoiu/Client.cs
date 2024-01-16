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
    class NoFall : Module
    {
        public NoFall() : base("NoFall", "Allows you to not get damaged due to fall damage",ModuleType.Toggle)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;


            player.fallValue = 0;
        }
    }
}
