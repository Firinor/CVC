using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Observers
{
    public class ResourceObserver : MonoBehaviour, IObserver<int>
    {
        [SerializeField]
        private TextMeshProUGUI text;
        [Inject(Id = "RedPlayer")]
        private Player player;
        [SerializeField]
        private EResource resource;

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(int value)
        {
            text.text = value.ToString();
        }

        private void OnEnable()
        {
            player[resource].Subscribe(this);
        }
    }
}