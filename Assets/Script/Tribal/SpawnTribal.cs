using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTribal : MonoBehaviour
{
    public GameObject[] tribalPrefabs;
    public int numberToSpawn;

    public int maxPos, minPos;

    private void Start()
    {
        SpawnRandomTribal();
    }

    private void SpawnRandomTribal()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {


            //int specificTribalIndex = 0 ;
            int randomTribalIndex = Random.Range(0, tribalPrefabs.Length);

            Vector3 randomSpawnPosition = new Vector3(Random.Range(minPos, maxPos), 0, Random.Range(minPos, maxPos));

            Instantiate(tribalPrefabs[randomTribalIndex], randomSpawnPosition, Quaternion.identity);
        }
    }
}
