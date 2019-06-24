using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followWaypoint : MonoBehaviour
{
    private GameObject waypoint;
    private Vector3 wayPointPos;
    public float speed = 6.0f;
    [SerializeField]
    private Material[] materials;
    private Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        waypoint = GameObject.Find("wayPoint");
    }

    // Update is called once per frame
    void Update()
    {
        wayPointPos = new Vector3(waypoint.transform.position.x, waypoint.transform.position.y, waypoint.transform.position.z);
        //Here, the enemy will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }

    public void ChangeColor(States state)
    {
        switch (state)
        {
            case States.Green:
                render.material = materials[1];
                break;
            case States.Red:
                render.material = materials[0];
                break;
            case States.Blue:
                render.material = materials[2];
                break;
        }
    }
 
}

