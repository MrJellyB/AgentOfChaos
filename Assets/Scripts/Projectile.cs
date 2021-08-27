using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 10f;
    public float speed = 0.1f;
    public int damage = 10;
    
    private float age = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        age += dt;
        this.transform.Translate(this.transform.forward * speed * dt, Space.World);

        if (age > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bullet hit");
    }
}
