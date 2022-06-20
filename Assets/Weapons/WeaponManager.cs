using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : ScriptableObject
{
    public GameObject prefab;
    public float WeaponDMG, WeaponMP, WeaponSTRReq, WeaponMAGReq, WeaponINTReq, WeaponFireRate;
    public int WeaponLvl;
    public string WeaponName;
    public Pallete Pallete;
}
