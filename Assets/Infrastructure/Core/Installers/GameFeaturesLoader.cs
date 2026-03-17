using System.Collections.Generic;
using Core.EventBus;
using Infrastructure.Core.ServiceLocator;
using UnityEngine;

namespace Core.Installers
{
    public class GameFeaturesLoader : MonoBehaviour
    {
        [Tooltip("Please remember to put views in correct order!"), Header("View List")]
        [SerializeField] private List<GameObject> views;
        [SerializeField] private GameObject parent;

        private List<GameObject> instantiatedViews = new();
        private IEventBus eventBus;
    
        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            eventBus = ServiceLocator.Instance.GetService<IEventBus>();
            SubscribeEvents();
            eventBus.Publish(new GameStartingEvent());
        }

        private void SubscribeEvents()
        {
            eventBus.Subscribe<GameStartingEvent>(GameStart);
            eventBus.Subscribe<BackToMainMenuEvent>(BackToMainMenu);
            eventBus.Subscribe<QuitGameEvent>(QuitGame);
        }

        private void QuitGame(QuitGameEvent obj)
        {
            DestroyFrontGameObjects();
        }

        private void GameStart(GameStartingEvent obj)
        {
            InstantiateFrontGameObjects();
        }

        private void BackToMainMenu(BackToMainMenuEvent obj)
        {
            DestroyFrontGameObjects();
            InstantiateFrontGameObjects();
        }
        
        private void DestroyFrontGameObjects()
        {
            foreach (var view in instantiatedViews)
            {
                Destroy(view); 
            }
        }
        
        private void InstantiateFrontGameObjects()
        {
            foreach (var view in views)
            {
                instantiatedViews.Add(Instantiate(view, parent.transform)); 
            }
        }

        private void UnSubscribeEvents()
        {
            eventBus.Unsubscribe<GameStartingEvent>(GameStart);
            eventBus.Unsubscribe<QuitGameEvent>(QuitGame);
        }
        
        private void OnDestroy()
        {
            UnSubscribeEvents();
        }
    }
    
    
    public struct QuitGameEvent : IEvent
    {
    }
    
    public struct BackToMainMenuEvent : IEvent
    {
    }
    
    public struct GameStartingEvent : IEvent
    {
    }
}