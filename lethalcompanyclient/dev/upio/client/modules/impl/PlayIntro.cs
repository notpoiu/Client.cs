using client.dev.upio.client;
using client.dev.upio.client.Modules;
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
    class PlayIntro : Module
    {
        public PlayIntro() : base("Play Intro", "intro", ModuleType.Button)
        {

        }

        public override void OnEnable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            StartOfRound.Instance.speakerAudioSource.PlayOneShot(StartOfRound.Instance.shipIntroSpeechSFX);
        }

    }
}
