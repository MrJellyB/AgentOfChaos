using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject spawnOnDeath;
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        if (spawnOnDeath)
        {
            Instantiate(spawnOnDeath, transform.position, transform.rotation);
        }
    }
}
