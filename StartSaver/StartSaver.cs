using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using UnityEngine;
using DaggerfallWorkshop.Game.Utility;
using System;

namespace StartSaver
{

    public class StartSaver : MonoBehaviour
    {
        static Mod mod;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<StartSaver>();
            StartGameBehaviour.OnStartGame += StartSaver_OnStartGame;
        }

        void Awake()
        {
            mod.IsReady = true;
            Debug.Log("[Start Saver] Ready");
        }


        private static void StartSaver_OnStartGame(object sender, EventArgs e)
        {
            Debug.Log("[Start Saver] Starting");
            PlayerEntity playerEntity = GameManager.Instance.PlayerEntity;
            string saveName = "Start Save";
            GameManager.Instance.SaveLoadManager.Save(playerEntity.Name, saveName);
            Debug.Log("[Start Saver] Game Saved");
        }


    }
}