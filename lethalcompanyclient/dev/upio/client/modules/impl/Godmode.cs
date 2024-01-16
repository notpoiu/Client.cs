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
    class Godmode : Module
    {
        public Godmode() : base("Godmode", "Allows you to not die!",ModuleType.Toggle)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;


            if (StartOfRound.Instance.allowLocalPlayerDeath)
                StartOfRound.Instance.allowLocalPlayerDeath = false;
        }

        public override void OnDisable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            if (!StartOfRound.Instance.allowLocalPlayerDeath)
                StartOfRound.Instance.allowLocalPlayerDeath = true;
        }


    }
}
