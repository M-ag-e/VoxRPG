using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using WeaponTypesNameSpace;

public class DEBUGWeaponSpawn : EditorWindow
{
    private int weaponSelect;

    Texture2D headerSectionTexture;
    Texture2D bodySectionTexture;

    Color headerSectionColor = new Color(61f / 255f, 61f / 255f, 61f / 255f, 1f);
    Color bodySectionColor = new Color(45f / 255f, 45f / 255f, 45f / 255f, 1f);

    Rect headerSection;
    Rect bodySection;

    static MagicWeaponData magicWpn;
    static MeleeWeaponData meleeWpn;
    static RangedWeaponData rangedWpn;

    public static MagicWeaponData MagicWeaponInfo { get { return magicWpn; } }
    public static MeleeWeaponData MeleeWeaponInfo { get { return meleeWpn; } }
    public static RangedWeaponData RangedWeaponInfo { get { return rangedWpn; } }


    [MenuItem("Window/DEBUG/WeaponSpawner")]
    static void OpenWindow()
    {
        DEBUGWeaponSpawn window = (DEBUGWeaponSpawn)GetWindow(typeof(DEBUGWeaponSpawn));
        window.minSize = new Vector2(200,200);
        window.Show();
    }
    private void OnEnable()
    {
        InitTextures();
        InitData();
    }

    public static void InitData()
    {
        magicWpn = (MagicWeaponData)ScriptableObject.CreateInstance(typeof(MagicWeaponData));
        meleeWpn = (MeleeWeaponData)ScriptableObject.CreateInstance(typeof(MeleeWeaponData));
        rangedWpn = (RangedWeaponData)ScriptableObject.CreateInstance(typeof(RangedWeaponData));
    }

    private void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        bodySectionTexture = new Texture2D(1, 1);
        bodySectionTexture.SetPixel(0, 0, bodySectionColor);
        bodySectionTexture.Apply();
    }
    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawBody();
    }
    private void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = position.width;
        headerSection.height = 50;

        bodySection.x = 0;
        bodySection.y = 50;
        bodySection.width = position.width;
        bodySection.height = position.height - 50;
        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(bodySection, bodySectionTexture);
    }
    private void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("## Debug Weapon Spawner ##");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Magic", GUILayout.Height(40)))
        {
            weaponSelect = 1;
        }
        if (GUILayout.Button("Melee", GUILayout.Height(40)))
        {
            weaponSelect = 2;
        }
        if (GUILayout.Button("Ranged", GUILayout.Height(40)))
        {
            weaponSelect = 3;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();


    }
    private void DrawBody()
    {
        GUILayout.BeginArea(bodySection);

        switch (weaponSelect)
        {
            case 1:
                GUILayout.Label("##### Magic Weapon #####");
                GUILayout.BeginHorizontal();
                GUILayout.Label("## Weapon Type ##");
                magicWpn.WeaponType = (MagicWeapon)EditorGUILayout.EnumPopup(magicWpn.WeaponType);  // Weapon Type Enum
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("## Damage Type ##");
                magicWpn.DamageType = (DamageTypes)EditorGUILayout.EnumPopup(magicWpn.DamageType);  // Damage Type Enum
                GUILayout.EndHorizontal();
                if (GUILayout.Button("Create", GUILayout.Height(40)))
                {
                    GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Magic);
                }
                break;
            case 2:
                GUILayout.Label("##### Melee Weapon #####");
                GUILayout.BeginHorizontal();
                GUILayout.Label("## Weapon Type ##");
                meleeWpn.WeaponType = (MeleeWeapon)EditorGUILayout.EnumPopup(meleeWpn.WeaponType);  // Weapon Type Enum
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("## Damage Type ##");
                meleeWpn.DamageType = (DamageTypes)EditorGUILayout.EnumPopup(meleeWpn.DamageType);  // Damage Type Enum
                GUILayout.EndHorizontal();
                if (GUILayout.Button("Create", GUILayout.Height(40)))
                {
                    GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Melee);
                }
                break;
            case 3:
                GUILayout.Label("##### Ranged Weapon #####");
                GUILayout.BeginHorizontal();
                GUILayout.Label("## Weapon Type ##");
                rangedWpn.WeaponType = (RangedWeapon)EditorGUILayout.EnumPopup(rangedWpn.WeaponType);  // Weapon Type Enum
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                GUILayout.Label("## Damage Type ##");
                rangedWpn.DamageType = (DamageTypes)EditorGUILayout.EnumPopup(rangedWpn.DamageType);  // Damage Type Enum  
                GUILayout.EndHorizontal();
                if (GUILayout.Button("Create", GUILayout.Height(40)))
                {
                    GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Ranged);
                }
                break;
            
        }

        GUILayout.EndArea();

    }
    public class GeneralSettings : EditorWindow
    {
        public enum SettingsType
        {
            Magic, 
            Melee, 
            Ranged
        }
        static SettingsType dataSettings;
        static GeneralSettings window;
        public static void OpenWindow(SettingsType setting)
        {
            dataSettings = setting;
            window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
            window.minSize = new Vector2(200, 200);
            window.Show();
        }

        private void OnGUI()
        {
            switch (dataSettings)
            {
                case SettingsType.Magic:
                    DrawSettings((WeaponManager)DEBUGWeaponSpawn.MagicWeaponInfo);
                    break;
                case SettingsType.Melee:
                    DrawSettings((WeaponManager)DEBUGWeaponSpawn.MeleeWeaponInfo);
                    break;
                case SettingsType.Ranged:
                    DrawSettings((WeaponManager)DEBUGWeaponSpawn.RangedWeaponInfo);
                    break;
            }
        }
        void DrawSettings(WeaponManager weaponData)
        {
            GUILayout.Label("##### Weapon Stats #####");
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Prefab      ");
            weaponData.prefab = (GameObject)EditorGUILayout.ObjectField(weaponData.prefab,typeof(GameObject),false);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("DMG        ");
            weaponData.WeaponDMG = EditorGUILayout.FloatField(weaponData.WeaponDMG);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("MP         ");
            weaponData.WeaponMP = EditorGUILayout.FloatField(weaponData.WeaponMP);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("STR Req    ");
            weaponData.WeaponSTRReq = EditorGUILayout.FloatField(weaponData.WeaponSTRReq);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("MAG Req    ");
            weaponData.WeaponMAGReq = EditorGUILayout.FloatField(weaponData.WeaponMAGReq);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("INT Req    ");
            weaponData.WeaponINTReq = EditorGUILayout.FloatField(weaponData.WeaponINTReq);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("FireRate   ");
            weaponData.WeaponFireRate = EditorGUILayout.FloatField(weaponData.WeaponFireRate);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Level      ");
            weaponData.WeaponLvl = EditorGUILayout.IntField(weaponData.WeaponLvl);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Name      ");
            weaponData.WeaponName = EditorGUILayout.TextField(weaponData.WeaponName);
            EditorGUILayout.EndHorizontal();
        }
    }
}
