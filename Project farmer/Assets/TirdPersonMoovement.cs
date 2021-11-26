using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirdPersonMoovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    float turnVelocity;

    public bool hasPlayer = false;
    public bool beingCarried = false;
    private bool touched = false;
    private float timeKeep = 0f;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float dist = Vector3.Distance(gameObject.transform.position, transform.position);
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(movDir.normalized * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E) && !beingCarried && timeKeep < Time.realtimeSinceStartup + 0.1f)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y -0.75f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 3))
            {
                Debug.Log("Lqunch");
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("Sheep"))
                    {
                        hit.collider.gameObject.transform.SetParent(this.transform);
                        hit.collider.gameObject.GetComponent<AnimalController>().enabled = false;
                        beingCarried = true;    
                        timeKeep = Time.realtimeSinceStartup;
                    }
                }
            }
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z), transform.TransformDirection(Vector3.forward)*3, Color.green);

        } else if (Input.GetKeyDown(KeyCode.E) && beingCarried && timeKeep < Time.realtimeSinceStartup + 0.1f)
        {
            Debug.Log("Touche");
            this.transform.GetChild(1).GetComponent<AnimalController>().enabled = true;
            this.transform.GetChild(1).transform.parent = null;
            beingCarried = false;
            timeKeep = Time.realtimeSinceStartup;
        }
        if (this.transform.childCount == 1 && beingCarried == true)
        {
            beingCarried = false;
        }
    }
}
