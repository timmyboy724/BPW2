using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontrigger : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(enemy);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
