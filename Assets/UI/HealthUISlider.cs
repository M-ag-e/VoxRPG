using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUISlider : MonoBehaviour
{
    public Slider sliderAmount;
    public TMP_Text sliderText;
    private float HPMax = 0, CurrentHP = 0;

    public void SetMaxHealthUI(float maxHealth)
    {
        sliderAmount.maxValue = maxHealth;
        HPMax = maxHealth;
        UpdateText();
    }

    public void UpdateHealthUI(int healthChange, float amount)
    {
        switch (healthChange) // 1 set // 2 add // 3 minus
        {
            case 1:
                sliderAmount.value = amount;
                CurrentHP = amount;
                break;
            case 2:
                sliderAmount.value += amount;
                CurrentHP += amount;
                break;
            case 3:
                sliderAmount.value -= amount;
                CurrentHP -= amount;
                break;
        }
        UpdateText();
    }
    private void UpdateText()
    {
        sliderText.text = CurrentHP + " / " + HPMax;
    }
}
