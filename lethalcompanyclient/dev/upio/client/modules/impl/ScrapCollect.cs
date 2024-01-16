using client.dev.upio.client;
using client.dev.upio.client.Modules;
using client.dev.upio.client.utils;
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
    class ScrapCollect : Module
    {
        public GrabbableObject[] grabbableObjectsUsed = new GrabbableObject[0];
        public System.Random random = new System.Random();
        public ScrapCollect() : base("Get Random Scrap", "gets all scrap",ModuleType.Button)
        {

        }

        public override void OnEnable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            GrabbableObject[] grabbableObjects = GameObject.FindObjectsOfType<GrabbableObject>();
            random.Shuffle(grabbableObjects);

            for (int i = 0; i < grabbableObjects.Length; i++)
            {
                if (grabbableObjects[i].grabbable == false) continue;
                if (grabbableObjects[i].playerHeldBy != null) continue;
                if (grabbableObjects[i] == null) continue;
                if (grabbableObjectsUsed.Contains(grabbableObjects[i])) continue;
                if (!grabbableObjects[i].itemProperties.isScrap) continue;
                if (grabbableObjects[i].isInElevator) continue;

                player.TeleportPlayer(grabbableObjects[i].transform.position);
                if (grabbableObjects[i].GetComponent<InteractTrigger>())
                {
                    Debug.Log("Found interact trigger");
                }

                grabbableObjectsUsed = (GrabbableObject[])grabbableObjectsUsed.Append(grabbableObjects[i]);
                break;
            }
        }

    }
}
