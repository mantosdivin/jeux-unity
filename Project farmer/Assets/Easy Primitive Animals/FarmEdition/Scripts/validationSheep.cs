using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validationSheep : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            Destroy(collision.gameObject);
        }
    }
}
