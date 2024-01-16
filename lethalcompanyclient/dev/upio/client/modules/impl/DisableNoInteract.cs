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
    class DisableNoInteract : Module
    {
        public DisableNoInteract() : base("Allow Interact Before ship", "long descro[topm",ModuleType.Toggle)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            GrabbableObject[] grabbableObjects = GameObject.FindObjectsOfType<GrabbableObject>();

            foreach (var obj in grabbableObjects)
            {
                if (obj == null) continue;
                if (obj.itemProperties.isScrap) continue;
                if (obj.isInElevator) continue;

                obj.itemProperties.canBeGrabbedBeforeGameStart = true;
            }



        }

    }
}
