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
    class Speed : Module
    {
        public float defaultValue = 0f;
        
        public Speed() : base("Speed", "401 real",ModuleType.Slider, 4.8f, 150f, 4.8f)
        {

        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            player.movementSpeed = this.currentValue;
        }
    }
}
