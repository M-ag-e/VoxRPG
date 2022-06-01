using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUISlider : MonoBehaviour
{
    public Slider sliderAmount;

    public void SetMaxHealthUI(int maxHealth)
    {
        sliderAmount.maxValue = maxHealth;
    }

    public void UpdateHealthUI(bool addHealth, float amount)
    {
        if (addHealth)
        {
            sliderAmount.value += amount;
        }
        else
        {
            sliderAmount.value -= amount;
        }
    }

    

}
