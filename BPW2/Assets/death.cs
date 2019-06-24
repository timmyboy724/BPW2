using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public GameObject GameOver;

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject);
        if (coll.gameObject.tag == "enemy")
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            GameOver.SetActive(true);
           // Destroy(gameObject);

        }
            
    }
}