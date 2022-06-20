using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : ScriptableObject
{
    public DamageType DamageType;
    public GameObject prefab;
    public float WeaponDMG, WeaponMP, WeaponSTRReq, WeaponMAGReq, WeaponINTReq, WeaponFireRate;
    public int WeaponLvl;
    public bool hasSpawned = false;

}
