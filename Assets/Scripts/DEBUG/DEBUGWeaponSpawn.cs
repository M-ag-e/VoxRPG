using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DEBUGWeaponSpawn : EditorWindow
{
    private Rect headerSection = new Rect(0, 0, Screen.width, 50);
    private Rect bodySection = new Rect(0,50,Screen.width,Screen.height);

    private Texture2D headerTexture;

    private Color headerTextureColour = new Color(54f / 255f, 61f / 255f, 61f / 255f, 1f);
    //private WeaponType WeaponType;

    //private WeaponType SpawnWeaponType;
    [MenuItem("Window/DEBUG/WeaponSpawner")]
    static void OpenWindow()
    {
        DEBUGWeaponSpawn window = (DEBUGWeaponSpawn)GetWindow(typeof(DEBUGWeaponSpawn));
        window.minSize = new Vector2(200, 200);
        window.Show();
    }
    private void OnEnable()
    {
        InitTextures();
    }
    private void InitTextures()
    {
        headerTexture = new Texture2D(1, 1);
        headerTexture.SetPixel(0, 0, headerTextureColour);
        headerTexture.Apply();
    }
    private void OnGUI()
    {
        DrawHeader();
        DrawBody();
    }
    private void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Weapon Debug Spawner");
        GUI.DrawTexture(headerSection, headerTexture);
        GUILayout.EndArea();
    }
    private void DrawBody()
    {
        GUILayout.BeginArea(bodySection);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type");
        //SpawnWeaponType = (WeaponType)EditorGUILayout.EnumPopup(WeaponType);
        EditorGUILayout.EndHorizontal();
        //GUILayout.Label("" + SpawnWeaponType);
        GUILayout.EndArea();

    }
}
