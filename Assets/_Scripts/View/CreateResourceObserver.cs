using System;
using UnityEngine;
using UnityEngine.UI;

namespace Observers
{
    public class CreateResourceObserver : MonoBehaviour, IObserver<float>
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private ResourseCreator creator;

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

        private void OnEnter()
        {
            slider.maxValue = creator.WorkRequired;
            creator.ProductionRate.Subscribe(this);
        }
    }
}
