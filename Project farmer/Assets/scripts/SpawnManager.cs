using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] SheepPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    // Start is called before the first frame update
    void Start()
    {

        spawnSheep();
    }
    public void spawnSheep()
    {
        for(int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Quaternion aleaRotate = new Quaternion(0, Random.Range(0, 360), 0, 360);
            Instantiate(SheepPrefabs[0], spawnPos, aleaRotate);
        }
    }
}