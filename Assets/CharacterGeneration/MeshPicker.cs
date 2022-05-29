using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPicker : MonoBehaviour
{
    public GameObject AttachedTo;
    public SkinnedMeshRenderer Head;
    public SkinnedMeshRenderer Body;
    public SkinnedMeshRenderer HandL;
    public SkinnedMeshRenderer HandR;
    public SkinnedMeshRenderer FootL;
    public SkinnedMeshRenderer FootR;

    private void Start()
    {
        if (AttachedTo.tag == "Player")
        {
            // Do nothing for now
        }
        if (AttachedTo.tag == "NPC")
        {
            Debug.Log("NPC Detected!");
            Head.enabled = false;
        }

    }
}
