using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;
    public Transform spawnGrenade;
    private Camera cam;
    public Vector3 cursor;

    private void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            cursor = hit.point;
            if (Input.GetMouseButtonDown(0))
            {
                GameObject gr = Instantiate(grenadePrefab, spawnGrenade.position, Quaternion.identity);

                //gr.GetComponent<Rigidbody>().velocity = Vo * throwForce;)
                gr.GetComponent<Rigidbody>().AddForce(spawnGrenade.forward * throwForce);

            }

        }
    }
}
