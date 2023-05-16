using Il2Cpp;
using Il2CppMirror;
using MelonLoader;
using UnityEngine;
using static UnityEngine.Object;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CustomPlayerCount
{
    public static class BuildInfo
    {
        public const string Name = "Custom Player Count menu"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Custom Player Count Menu"; // Description for the Mod.  (Set as null if none)
        public const string Author = "WoodgamerHD"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "DO NOT FUCKEN REPOST OR CLAIMS ARE YOURS"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = ""; // Download Link for the Mod.  (Set as null if none)
    }


    public class CustomPlayerCount : MelonMod
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           //new                                                                                    
        private Rect MainWindow;
       
        NetworkManager nm;
        private bool showMenucount = true; // Whether to show the menu or not
        bool updatecount = false;
        int Playercount = 8;
        bool isMainMenu = false;
        float natNextUpdateTime;
     
        public static List<InGameLobby> InGameLobby = new List<InGameLobby>();

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "MainMenu")
            {
                isMainMenu = true;
             
                LoggerInstance.Msg("WARNING: No testing has been done past 7 players so crashes or lag may occur past 7 players!");
            }
            else
            {
                isMainMenu = false;
               
            }
        }

        public override void OnUpdate()
        {
            natNextUpdateTime += Time.deltaTime;

            if (natNextUpdateTime >= 3f)
            {
                InGameLobby = FindObjectsOfType<InGameLobby>().ToList();
                natNextUpdateTime = 0f;
            }
            if (Keyboard.current.f1Key.wasPressedThisFrame)
            {
                showMenucount = !showMenucount;

            }

            if (updatecount && isMainMenu)
            {
                LoggerInstance.Msg("updated");
                nm = FindObjectOfType<NetworkManager>();
                nm.maxConnections = Playercount;
                GameNetworkManager.MaxPlayersPerRoom = Playercount;
            }
            
        }
       

        public override void OnInitializeMelon()
        {
           
          
        MainWindow = new Rect(0, 0, 250f, 150f);
        }


        //
        public void RenderUI(int id)
        {


            if (GUILayout.Button(updatecount ? "Update" : "Update", GUILayout.ExpandWidth(true)))
            {
                GameNetworkManager.MaxPlayersPerRoom = Playercount;

                foreach (InGameLobby player in InGameLobby)
                {
                    player.m_MaxRoomPlayers = Playercount;

                }
             
                LoggerInstance.Msg("New button clicked");
                LoggerInstance.Msg(isMainMenu);
                updatecount = false;
            }
          


            GUILayout.Label("Player Count: " + Playercount.ToString("F2"));
            Playercount = (int)GUILayout.HorizontalSlider(Playercount, 0.0f, 100.0f, GUILayout.Height(100)); 

    
            GUI.DragWindow();
        }


        public override void OnGUI()
        {
            GUI.Label(new Rect(10, 10, 1000, 1000), "<size=15>"+ Playercount + "</size>"
              
               );

            if (showMenucount)
            {
                MainWindow = GUI.Window(9, MainWindow, (GUI.WindowFunction)RenderUI, "Player Count<WoodgamerHD>"); 

            }

        }
    }
}