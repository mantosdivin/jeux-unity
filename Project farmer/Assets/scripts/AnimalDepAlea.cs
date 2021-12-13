using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDepAlea : MonoBehaviour
{
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            transform.Rotate(Vector3.up * Random.Range(30, 260));
        }
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.TransformDirection(Vector3.forward) * 3, Color.green);
    }
}
