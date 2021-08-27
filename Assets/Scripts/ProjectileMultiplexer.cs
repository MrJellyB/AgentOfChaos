using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileMultiplexer : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int multiplyAmount = 2;
    public float angle = 90f;
    public float spread = 2.5f;

    private void OnTriggerEnter(Collider other)
    {
        var originalProj = other.gameObject.GetComponentInParent<Projectile>();
        if (originalProj != null)
        {
            SpawnProjectiles(other.transform.rotation.eulerAngles.y);
            GameObject.Destroy(other.gameObject);
        }
    }

    private void SpawnProjectiles(float originalY)
    {
        var spawnAmount = multiplyAmount;
        var isOdd = multiplyAmount % 2 != 0;
        if (isOdd)
        {
            spawnAmount -= 1;
        }
        //spawn at angle intervals from the original direction to the left and right.
        for (int i = 0; i < spawnAmount; i+= 2)
        {
            SpawnProjectile(originalY + angle * (i+1) + Random.Range(-spread,spread));
            SpawnProjectile(originalY - angle * (i+1) + Random.Range(-spread,spread));
        }
        //if the amount to spawn is odd, there will be a middle bullet left that is going to the original direction
        if (isOdd)
        {
            SpawnProjectile(originalY);
        }
    }

    private void SpawnProjectile(float y)
    {
        var g = Instantiate(projectilePrefab, this.transform.position, Quaternion.Euler(0, y, 0));
        g.transform.Translate(g.transform.forward, Space.World);
    }
}
