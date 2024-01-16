using client.dev.upio.client.UI;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace client.dev.upio.client
{
    public class Client : MonoBehaviour
    {

        public void Start()
        {
            Debug.Log("Client.cs v1 started!");


            Modules.ModuleManager.Init();
            MenuUI.Init();
        }


        // Events
        public void Update()
        {
            MenuUI.Update();

            for (int i = 0; i < Modules.ModuleManager.Modules.Count; i++)
            {
                if (Modules.ModuleManager.Modules[i].IsEnabled)
                {
                    Modules.ModuleManager.Modules[i].OnUpdate();
                }
            }
        }


        public void OnGUI()
        {
            for (int i = 0; i < Modules.ModuleManager.Modules.Count; i++)
            {
                if (Modules.ModuleManager.Modules[i].IsEnabled)
                {
                    Modules.ModuleManager.Modules[i].OnGUI();
                }
            }
            MenuUI.OnGUI();
        }
    }
}
