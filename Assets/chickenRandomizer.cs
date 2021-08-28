using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class chickenRandomizer : MonoBehaviour
{
    public SkinnedMeshRenderer MeshRenderer;

    public Mesh[] PossibleMeshes;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer.sharedMesh = PossibleMeshes[Random.Range(0, PossibleMeshes.Length)];
    }
}
