using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnjController : MonoBehaviour
{
    public GameObject listSheep;
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        int nbSheep = listSheep.transform.childCount;
        float minDistance = 100000f;
        Vector3 minPosSheep = Vector3.zero;
        for (int i = 0; i <nbSheep; i++)
        {
            float dist = Vector3.Distance(this.transform.position, listSheep.transform.GetChild(i).transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                minPosSheep = listSheep.transform.GetChild(i).transform.position;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, minPosSheep, speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            Destroy(collision.gameObject);
        }
    }
}
