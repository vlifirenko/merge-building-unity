using System;
using Building.Game.GameRoot;
using Building.Game.MainMenu.Root.View;
using UnityEngine;

namespace Building.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        public event Action GoToGameplaySceneRequested;
        
        [SerializeField] private UIMainMenuRootBinder sceneUIRootPrefab;
        
        public void Run(UIRootView uiRoot)
        {
            var uiScene = Instantiate(sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToGameplayButtonClicked += 
                () => GoToGameplaySceneRequested?.Invoke();
        }
    }
}