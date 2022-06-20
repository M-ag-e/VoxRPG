using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponTypesNameSpace;

[CreateAssetMenuAttribute(fileName = "New Melee Weapon Data", menuName = "WeaponData/Melee")]
public class MeleeWeaponData : WeaponManager
{
    public MeleeWeapon WeaponType;
}
