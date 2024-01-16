using client.dev.upio.client.modules;
using client.dev.upio.client.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace client.dev.upio.client.UI
{
    public class MenuUI
    {
        public static Rect windowRect = new Rect(0, 0, 350, 500);
        public static bool IsVisible = true;
        public static float maxWidth = 0f;

        public static void Init()
        {
            foreach (var module in ModuleManager.Modules)
            {
                float width = module.Name.Length * 10 + 25;
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
            }

            if (IsVisible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        [DllImport("User32.dll")]
        private static extern bool GetAsyncKeyState(int key);

        public static void Update()
        {
            if (GetAsyncKeyState(45))
            {
                IsVisible = !IsVisible;

                if (IsVisible)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }

        public static void OnGUI()
        {
            if (MenuUI.IsVisible)
            {
                windowRect = GUI.Window(0, windowRect, DrawGUIContent, "Client.cs | by upio");
            }
            
        }

        public static void DrawGUIContent(int windowId)
        {

            for (int i = 0; i < ModuleManager.Modules.Count; i++)
            {

                if (ModuleManager.Modules[i].Type.Equals(ModuleType.Slider))
                {
                    GUI.Label(new Rect(10, 15+(i * 20), 100, 20), ModuleManager.Modules[i].Name);

                    float addX = ModuleManager.Modules[i].Name.ToString().Length * 10;
                    ModuleManager.Modules[i].currentValue = GUI.HorizontalSlider(new Rect(10 + addX, 20 + (i * 20), 100, 20), ModuleManager.Modules[i].currentValue, ModuleManager.Modules[i].minVal, ModuleManager.Modules[i].maxVal);
                    ModuleManager.Modules[i].Enabled = true;
                    continue;

                } else if (ModuleManager.Modules[i].Type.Equals(ModuleType.Toggle))
                {
                    ModuleManager.Modules[i].Enabled = GUI.Toggle(new Rect(10, 20 + (i * 20), 100, 20), ModuleManager.Modules[i].Enabled, ModuleManager.Modules[i].Name);

                    if (ModuleManager.Modules[i].Enabled)
                    {
                        if (!ModuleManager.Modules[i].didInit)
                        {
                            ModuleManager.Modules[i].OnEnable();
                            ModuleManager.Modules[i].didInit = true;
                        }
                    }
                    else
                    {
                        if (ModuleManager.Modules[i].didInit)
                        {
                            ModuleManager.Modules[i].OnDisable();
                            ModuleManager.Modules[i].didInit = false;
                        }
                    }
                    
                    continue;
                } else if (ModuleManager.Modules[i].Type.Equals(ModuleType.Button))
                {
                    if (GUI.Button(new Rect(10, 20 + (i * 25), maxWidth, 20), ModuleManager.Modules[i].Name))
                    {
                        ModuleManager.Modules[i].OnEnable();
                    }
                    continue;
                }
            }

            GUI.DragWindow(new Rect(0, 0, 10000, 10000));

        }


    }
}
