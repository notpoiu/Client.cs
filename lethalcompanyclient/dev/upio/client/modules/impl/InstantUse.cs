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
    class InstantUse : Module
    {
        public InstantUse() : base("Instant Use", "proximity prompt fr",ModuleType.Toggle)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;


            InteractTrigger trigger = player.hoveringOverTrigger;

            if (trigger == null) return;

            trigger.interactable = true;
            trigger.timeToHold = 0f;
        }
    }
}
