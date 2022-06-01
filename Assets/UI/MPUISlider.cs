using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPUISlider : MonoBehaviour
{
    public Slider sliderAmount;

    public void SetMaxMPUI(int maxMP)
    {
        sliderAmount.maxValue = maxMP;
    }

    public void UpdateMPUI(bool addMP, float amount)
    {
        if (addMP)
        {
            sliderAmount.value += amount;
        }
        else
        {
            sliderAmount.value -= amount;
        }
    }



}
