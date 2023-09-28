using System;
using UnityEngine;
using UnityEngine.UI;

namespace Observers
{
    public class CreateUnitObserver : MonoBehaviour, IObserver<float>
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private UnitCreator creator;

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw error;
        }

        public void OnNext(float value)
        {
            slider.value = slider.maxValue - value;
        }

        private void OnEnable()
        {
            slider.maxValue = creator.MaxValue;
            creator.ProductionRate.Subscribe(this);
        }
    }
}