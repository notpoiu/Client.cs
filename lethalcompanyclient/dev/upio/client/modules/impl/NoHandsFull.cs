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
    class NoHandsFull : Module
    {
        public NoHandsFull() : base("No Hands Full", "[Hands opened]",ModuleType.Toggle)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;


            player.twoHanded = false;
        }

    }
}
