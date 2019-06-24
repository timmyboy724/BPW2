using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float ExplosionRadius = 6f;
    public float force = 1000f;
    [Range(0,20)]
    [SerializeField]
    private float grenadeRadius;
    float countdown;
    private Camera cam;
    private Vector3 mousePosition;
    private float throwspeed;

    [SerializeField]
    public grenadeThrower gren;

    bool hasExploded = false;

    public GameObject explosionEffect;

    void Start()
    {
        countdown = delay;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
        else
        {

            //      Move(); 
        }

    }
  
    void Explode()
    {
        GameObject Particle = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(Particle, 1);

        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, ExplosionRadius);
            }

            // damage
            if (Vector3.Distance(transform.position, nearbyObject.transform.position) < 20)
            {
                Debug.Log("Destroy");

                if (nearbyObject.gameObject.GetComponent<Enemy>())
                {
                    Destroy(nearbyObject.gameObject);
                    ScoreObject.instance.IncreaseScore();
                }
            }
        }

        Destroy(gameObject);
    }

    public void Move()
    {
        throwspeed = gren.throwForce * Time.deltaTime;
        transform.position = Vector3.MoveTowards(gren.spawnGrenade.position, gren.cursor, throwspeed);
    }


}
