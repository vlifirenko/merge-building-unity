using System;
using Building.Game.Gameplay.Root.View;
using Building.Game.GameRoot;
using UnityEngine;

namespace Building.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public event Action GoToMenuSceneRequested;
        
        [SerializeField] private UIGameplayRootBinder sceneUIRootPrefab;
        
        public void Run(UIRootView uiRoot)
        {
            var uiScene = Instantiate(sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            uiScene.GoToMainMenuButtonClicked += 
                () => GoToMenuSceneRequested?.Invoke();
        }
    }
}