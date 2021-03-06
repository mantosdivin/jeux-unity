using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] SheepPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    public Transform listSheep;
    private int numberSheep = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnSheep();
    }
    public void spawnSheep()
    {
        numberSheep = menu.diffitculty * 5;
        for(int i = 0; i < numberSheep; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Quaternion aleaRotate = new Quaternion(0, Random.Range(0, 360), 0, 360);
            GameObject newSheep = Instantiate(SheepPrefabs[0], spawnPos, aleaRotate);
            newSheep.transform.parent = listSheep;
        }
    }
}
