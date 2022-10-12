using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Spawner : MonoBehaviour
{
    GameObject block;

    GameObject blockToUse;

    [SerializeField]
    float timeToSpawn;

    float timeToSpawnReset;

    bool canSpawn;

    int countSpawm = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawnReset = timeToSpawn;
        block = Resources.Load<GameObject>("Square");
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawn)
        {
            timeToSpawn -= Time.deltaTime;
            countSpawm++;
            if (timeToSpawn < 0)
            {
                timeToSpawn = timeToSpawnReset;
                if (countSpawm > 1)
                    block.transform.localScale =   new Vector3(Random.Range(1.3f, 2.567734f), Random.Range(2f, 4f), 1);
                Instantiate(block, transform.position, Quaternion.identity);
            }
        }
    }

    public void CanSpawn(bool can)
    {
        if (can)
            timeToSpawn = Random.Range(0.4f, 0.68f);

        canSpawn = can;
    }
}
