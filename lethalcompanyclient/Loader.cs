using client.dev.upio.client;
using client.dev.upio.client.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Loader
    {
        static UnityEngine.GameObject gameObject;   

        public static void Load()
        {
            gameObject = new UnityEngine.GameObject();
            gameObject.AddComponent<Client>();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
            MenuUI.windowRect = UnityEngine.Rect.MinMaxRect(0, 0, 0, 0);
            MenuUI.IsVisible = false;
        }
    }
}
