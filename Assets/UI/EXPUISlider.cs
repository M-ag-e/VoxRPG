using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPUISlider : MonoBehaviour
{
    public Slider sliderAmount;


    public void SetMaxEXPUI(float maxEXP)
    {
        sliderAmount.maxValue = maxEXP;
    }

    public void UpdateEXPUI(int EXPChange, float amount)
    {
        switch (EXPChange) // 1 set // 2 add // 3 minus
        {
            case 1:
                sliderAmount.value = amount;
                break;
            case 2:
                sliderAmount.value += amount;
                break;
            case 3:
                sliderAmount.value -= amount;
                break;
        }
    }
}
