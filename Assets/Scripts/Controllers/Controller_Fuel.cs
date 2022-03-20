using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Controllers
{
    public class Controller_Fuel : MonoBehaviour
    {
        public Slider slider;

        public const float FuelMax = 100;
        public float currentFuel;
        public float timeInSeconds = 60;
        public float interval;
        
        public float elapsed = 0f;
        void Start()
        {
            interval = FuelMax / timeInSeconds;
            currentFuel = FuelMax;
            SetFuel(currentFuel);
        }
        
        void Update()
        {
            elapsed += Time.deltaTime;
            if (!(elapsed >= 1f)) return;
            elapsed %= 1f;
            LowerFuel();
        }

        public void LowerFuel()
        {
            currentFuel -= interval;
            SetFuel(currentFuel);

            if (currentFuel <= 0)
            {
                // Change to losing screen
            }
        }

        public void SetFuel(float amount)
        {
            slider.value = amount;
        }
    }
}
