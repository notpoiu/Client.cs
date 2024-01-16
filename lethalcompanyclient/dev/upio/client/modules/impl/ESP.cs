using client.dev.upio.client;
using client.dev.upio.client.Modules;
using client.dev.upio.client.utils;
using GameNetcodeStuff;
using Steamworks.Ugc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace client.dev.upio.client.modules.impl
{
    class ESP : Module
    {
        public float offsetPlayer = 1.5f;
        public float offsetScrap = 0f;
        public float offsetEnemy = 1.5f;

        public ESP() : base("ESP", "ESP", ModuleType.Toggle)
        {

        }

        public override void OnGUI()
        {
            PlayerControllerB localPlayer = GameNetworkManager.Instance.localPlayerController;

            Camera camera = localPlayer.gameplayCamera;

            if (localPlayer == null || camera == null)
                return;

            // Player ESP
            for (int i = 0; i < StartOfRound.Instance.allPlayerObjects.Length; i++)
            {
                try
                {
                    PlayerControllerB player = StartOfRound.Instance.allPlayerObjects[i].GetComponent<PlayerControllerB>();

                    if (player == null || player == localPlayer)
                        continue;

                    Vector3 pivotPos = player.transform.position;
                    Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - offsetPlayer; //At the feet
                    Vector3 playerHeadPos; playerHeadPos.x = pivotPos.x; playerHeadPos.z = pivotPos.z; playerHeadPos.y = pivotPos.y + offsetPlayer; //At the head

                    Vector3 w2s_footpos = camera.WorldToScreenPoint(playerFootPos);
                    Vector3 w2s_headpos = camera.WorldToScreenPoint(playerHeadPos);

                    if (w2s_footpos.z > 0f)
                    {
                        DrawBoxESP(w2s_footpos, w2s_headpos, offsetPlayer,Color.red);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("EXCEPTION WHILE RENDERING PLAYER ESP");
                    Debug.Log(e);
                }
                
            }

            // Scrap ESP
            foreach(GrabbableObject item in GameObject.FindObjectsOfType<GrabbableObject>())
            {
                try
                {
                    if (item == null || item.gameObject == null) continue;

                    Vector3 itemPos = item.gameObject.transform.position;
                    Vector3 itemFootPos; itemFootPos.x = itemPos.x; itemFootPos.y = itemPos.y - offsetScrap; itemFootPos.z = itemPos.z;
                    Vector3 itemHeadPos; itemHeadPos.x = itemPos.x; itemHeadPos.y = itemPos.y + offsetScrap; itemHeadPos.z = itemPos.z;
                                      
                    Vector3 itemHeadScreenPos = camera.WorldToScreenPoint(itemHeadPos);
                    Vector3 itemFootScreenPos = camera.WorldToScreenPoint(itemFootPos);

                    if (itemFootScreenPos.z > 0)
                    {
                        DrawBoxESP(itemHeadScreenPos, itemFootScreenPos, offsetScrap, Color.green);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("EXCEPTION WHILE RENDERING ITEM ESP");
                    Debug.Log(e);
                }
            }

            foreach(EnemyAI enemy in GameObject.FindObjectsOfType<EnemyAI>())
            {
                try {
                    if (enemy == null || enemy.gameObject == null) continue;

                    Vector3 enemyPos = enemy.gameObject.transform.position;
                    Vector3 enemyFootPos; enemyFootPos.x = enemyPos.x; enemyFootPos.y = enemyPos.y - offsetEnemy; enemyFootPos.z = enemyPos.z;
                    Vector3 enemyHeadPos; enemyHeadPos.x = enemyPos.x; enemyHeadPos.y = enemyPos.y + offsetEnemy; enemyHeadPos.z = enemyPos.z;

                    Vector3 enemyHeadScreenPos = camera.WorldToScreenPoint(enemyHeadPos);
                    Vector3 enemyFootScreenPos = camera.WorldToScreenPoint(enemyFootPos);

                    if (enemyHeadScreenPos.z > 0 && enemyFootScreenPos.z > 0)
                    {
                        DrawBoxESP(enemyHeadScreenPos, enemyFootScreenPos, offsetEnemy, Color.yellow);
                    }
                }catch(Exception e)
                {
                    Debug.Log("EXCEPTION WHILE RENDERING ENEMY ESP");
                    Debug.Log(e);
                }
            }
        }

        public void DrawBoxESP(Vector3 footpos, Vector3 headpos, float widthOffset,Color color) //Rendering the ESP
        {
            float height = headpos.y - footpos.y;
            float width = height / widthOffset;

            RenderUtils.DrawBox(footpos.x - (width / 2), (float)Screen.height - footpos.y - height, width, height, color, 2f);
            RenderUtils.DrawLine(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(footpos.x, (float)Screen.height - footpos.y), color, 2f);
        }

    }
}
