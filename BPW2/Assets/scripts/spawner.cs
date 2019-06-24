using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public BoxCollider spawn;
    public float spawntime;

    float timer;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawntime)
        {
            timer = 0;

            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 positionInBox = new Vector3(Random.Range(-spawn.extents.x, spawn.extents.x), Random.Range(-spawn.extents.y, spawn.extents.y), Random.Range(-spawn.extents.z, spawn.extents.z));
        Vector3 spawnPos = spawn.transform.TransformPoint(positionInBox);
        GameObject enemyClone = Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }
}
