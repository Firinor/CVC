using System;
using UnityEngine;
using UnityEngine.UI;

namespace Observers
{
    public class CastleObserver : MonoBehaviour, IObserver<float>
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private Castle castle;

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(float value)
        {
            slider.value = value;
        }

        private void OnEnable()
        {
            slider.maxValue = castle.MaxValue;
            castle.ProductionRate.Subscribe(this);
        }
    }
}