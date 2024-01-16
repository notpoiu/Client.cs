using client.dev.upio.client.Modules;
using GameNetcodeStuff;

namespace client.dev.upio.client.modules.impl
{
    class NightVision : Module
    {
        public UnityEngine.Color oldColor;
        public float oldIntensity;
        public float oldRange;
        public bool oldEnabled;
        
        public NightVision() : base("Night Vision", "real",ModuleType.Toggle)
        {

        }

        public override void OnEnable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            oldColor = player.nightVision.color;
            oldIntensity = player.nightVision.intensity;
            oldRange = player.nightVision.range;
            oldEnabled = player.nightVision.enabled;
        }

        public override void OnUpdate()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            player.nightVision.enabled = true;
            player.nightVision.color = UnityEngine.Color.white;
            player.nightVision.intensity = 1000f;
            player.nightVision.range = 1000f;
        }

        public override void OnDisable()
        {
            PlayerControllerB player = GameNetworkManager.Instance.localPlayerController;

            if (player == null)
                return;

            
            player.nightVision.color = oldColor;
            player.nightVision.intensity = oldIntensity;
            player.nightVision.range = oldRange;
            player.nightVision.enabled = oldEnabled;
        }


    }
}
