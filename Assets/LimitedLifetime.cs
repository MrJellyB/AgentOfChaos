using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLifetime : MonoBehaviour
{
    public float lifeTime = 10f;

    private float age = 0f;
    // Start is called before the first frame update
    void Start()
    {
        age = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        age += dt;
        
        if (age >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
