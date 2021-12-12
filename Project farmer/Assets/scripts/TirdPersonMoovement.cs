 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TirdPersonMoovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private AudioSource soundSheep;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI WinnerText;
    public GameObject listSheep;
    public pnjController pnjController;
    public validationSheep validationSheep;
    public Timer timer;
    public float speed = 10f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    float turnVelocity;
    public bool hasPlayer = false;
    public bool beingCarried = false;
    private bool touched = false;
    private float timeKeep = 0f;
    public bool isGameActive;
    public Button restartButton;
    public Button MenuButton;
    Vector3 velocity;

    private void Start()
    {
        soundSheep = GetComponent<AudioSource>();
        isGameActive = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (isGameActive == true) {
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
                soundSheep.Play();
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y -0.75f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 3))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.CompareTag("Sheep"))
                        {
                            hit.collider.gameObject.transform.SetParent(this.transform);
                            hit.collider.gameObject.GetComponent<AnimalDepAlea>().enabled = false;
                            beingCarried = true;    
                            timeKeep = Time.realtimeSinceStartup;
                        }
                    }
                }
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.75f, transform.position.z), transform.TransformDirection(Vector3.forward)*3, Color.green);

            } else if (Input.GetKeyDown(KeyCode.E) && beingCarried && timeKeep < Time.realtimeSinceStartup + 0.1f)
            {
                //Debug.Log("Touche");
                this.transform.GetChild(1).GetComponent<AnimalDepAlea>().enabled = true;
                this.transform.GetChild(1).transform.parent = null;
                beingCarried = false;
                timeKeep = Time.realtimeSinceStartup;
                soundSheep.Play();

            }
            if (this.transform.childCount == 1 && beingCarried == true)
            {
                beingCarried = false;
            }
            
        }
        GameOver();
        Winner();
    }
    public void GameOver()
    {
        int nbSheep = listSheep.transform.childCount;
        Debug.Log("nbSheep = " + nbSheep);
        if ((nbSheep == 0 && pnjController.score > validationSheep.score) || (timer.timeValue == 0 && pnjController.score > validationSheep.score))
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            MenuButton.gameObject.SetActive(true);
            isGameActive = false;
            
        }
    }
    public void Winner()
    {
        int nbSheep = listSheep.transform.childCount;
        if (nbSheep == 0 && pnjController.score <= validationSheep.score || (timer.timeValue == 0 && pnjController.score <= validationSheep.score))
        {
            WinnerText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            MenuButton.gameObject.SetActive(true);
            isGameActive = false;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene("1", LoadSceneMode.Single);
    }
}
