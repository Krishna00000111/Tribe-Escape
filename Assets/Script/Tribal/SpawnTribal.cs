using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTribal : MonoBehaviour
{
    public GameObject[] tribalPrefabs;
    public int numberToSpawn;

    public int maxPosX, minPosX;
    public int maxPosZ, minPosZ;

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

            Vector3 randomSpawnPosition = new Vector3(Random.Range(minPosX, maxPosX), 0, Random.Range(minPosZ, maxPosZ));

            Instantiate(tribalPrefabs[randomTribalIndex], randomSpawnPosition, Quaternion.Euler(0,Random.Range(0, 360), 0));
        }
    }
}
