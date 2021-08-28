using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

public class chickenRandomizer : MonoBehaviour
{
    public SkinnedMeshRenderer MeshRenderer;
    public Animator chickenAnimator;
    public Mesh[] PossibleMeshes;
    // Start is called before the first frame update
    void Start()
    {
        chickenAnimator.SetFloat("Offset",Random.Range(0f,1f));
        MeshRenderer.sharedMesh = PossibleMeshes[Random.Range(0, PossibleMeshes.Length)];
    }
}
