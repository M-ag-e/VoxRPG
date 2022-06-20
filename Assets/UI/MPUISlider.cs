using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MPUISlider : MonoBehaviour
{
    public Slider sliderAmount;
    public TMP_Text sliderText;
    private float MPMax = 0, CurrentMP = 0;
    public void SetMaxMPUI(float maxMP)
    {
        sliderAmount.maxValue = maxMP;
        MPMax = maxMP;
        UpdateText();
    }



    public void UpdateMPUI(int MPChange, float amount)
    {
        switch (MPChange) // 1 set // 2 add // 3 minus
        {
            case 1:
                sliderAmount.value = amount;
                CurrentMP = amount;
                break;
            case 2:
                sliderAmount.value += amount;
                CurrentMP += amount;
                break;
            case 3:
                sliderAmount.value -= amount;
                CurrentMP -= amount;
                break;
        }
        UpdateText();
    }
    private void UpdateText()
    {
        sliderText.text = CurrentMP + " / " + MPMax;
    }


}
