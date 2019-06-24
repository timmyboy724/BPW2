using UnityEngine;


public class randomforce : MonoBehaviour
{
    public GameObject enemy;
    public float minForce = 5f;
    public float maxForce = 12f;
    

    void Update()
    {

        Random.Range(minForce, maxForce);
       
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(minForce, maxForce), 0, Random.Range(minForce, maxForce)),ForceMode.Impulse);

    }

}
