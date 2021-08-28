using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggSpawner : MonoBehaviour
{
    public GameObject egg;
    public int eggChance = 50;
    public float eggForce = 1f;

    private void OnDestroy()
    {
        if (eggChance >= Random.Range(1, 101))
        {
            Vector3 rotation = Random.onUnitSphere;
            var eggObj = Instantiate(egg, transform.position, Quaternion.Euler(rotation));
            var eggRb = eggObj.GetComponent<Rigidbody>();
            eggRb.AddForce(Random.onUnitSphere * eggForce);
        }
    }
}
