using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefabToSpawn;
    public float spawnEvery;
    float spawnIn;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        spawnIn = spawnEvery;
    }

    // Update is called once per frame
    void Update()
    {
        spawnIn -= Time.deltaTime;
        if (spawnIn < 0)
        {
            Spawn();
            spawnIn = spawnEvery;
        }
    }

    void Spawn()
    {
        var pos = this.gameObject.transform.position;
        Instantiate(prefabToSpawn, pos, Quaternion.identity);
    }
}
