using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    public int healthRestored = 5;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            var es = other.gameObject.GetComponentInChildren<EntityStats>();
            es.AddHP(healthRestored);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
