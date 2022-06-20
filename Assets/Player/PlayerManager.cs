using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static ClassType PlayerClass;
    public static float PlayerExp, PlayerSTR, PlayerMAG, PlayerINT, PlayerHP, PlayerMP;
    public static int PlayerLevel;
    public static bool Spawned;
    public HealthUISlider HPUI;
    public MPUISlider MPUI;
    public EXPUISlider EXPUI;
    private void Awake()
    {
        if (!Spawned)
        {
            Spawned = true;
            PlayerGenerateStatsOnSpawn();
        }
    }
    public void PlayerAddExperience(float exp)
    {
        Debug.Log("Player gained " + exp + " experience");
        PlayerExp += exp;
        if (PlayerExp >= PlayerLevel * 10)
        {
            PlayerAddLevel();
        }
    }

    public void PlayerAddLevel()
    {
        Debug.Log("Player Leveled Up! Current Level is "+PlayerLevel);
        PlayerExp = 0;
        PlayerLevel += 1;
    }

    public void PlayerGenerateStatsOnSpawn()
    {
        PlayerLevel = 1;
        PlayerExp = 0;
        PlayerSTR = 0;
        PlayerINT = 0;
        PlayerMAG = 0;
        PlayerHP = 10;
        PlayerMP = 0;
        HPUI.SetMaxHealthUI(PlayerHP);
        HPUI.UpdateHealthUI(1, PlayerHP);
        MPUI.SetMaxMPUI(PlayerMP);
        MPUI.UpdateMPUI(1, PlayerMP);
        EXPUI.SetMaxEXPUI(PlayerExp);
        EXPUI.UpdateEXPUI(1, PlayerExp);

        
    }

    public void PlayerGenerateStatsOnClass()
    {
        switch (PlayerClass)
        {
            case ClassType.Mage:
                break;
            case ClassType.Rouge:
                break;
            case ClassType.Ranger:
                break;
            case ClassType.Knight:
                break;
            default:
                Debug.Log("Invalid Class");
                break;
        }
        Debug.Log("Player Class is " + PlayerClass);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 20, 100, 20), "EXP = " + PlayerExp, "box");
        GUI.Label(new Rect(0, 40, 100, 20), "STR = " + PlayerSTR, "box");
        GUI.Label(new Rect(0, 60, 100, 20), "MAG = " + PlayerMAG, "box");
        GUI.Label(new Rect(0, 80, 100, 20), "INT = " + PlayerINT, "box");
        GUI.Label(new Rect(0, 100, 100, 20), "LVL = " + PlayerLevel, "box");
    }
}
