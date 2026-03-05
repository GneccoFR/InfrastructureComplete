using System;
using Core.Infrastructure;
using Infrastructure.Core.UI.PresenterExample;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Infrastructure.Core.UI.ViewExample
{
    public class PingPongTestView : MonoBehaviour, IView
    {
        [SerializeField] private Button pingButton;
        [SerializeField] private TextMeshProUGUI pongText;
        private PingPongTestPresenter _presenter;
        
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _presenter = new PingPongTestPresenter(this);
            _presenter.Initialize();
            pongText.text = "";
            pingButton.onClick.AddListener(OnPingButtonClicked);
        }

        public void TogglePongText(bool isActive)
        {
            pongText.gameObject.SetActive(isActive);
        }
        
        private void OnPingButtonClicked()
        {
            _presenter.PingButtonPressed();
        }

        public void SetPongText(string pong)
        {
            pongText.text = pongText.text + " " + pong;
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
        }
    }
}
