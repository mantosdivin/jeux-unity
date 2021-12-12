using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class pnjController : MonoBehaviour
{
    public GameObject listSheep;
    private Animator animator;
    private AudioSource SoundSheep;
    public TextMeshProUGUI scoreWolfText;
    public TirdPersonMoovement tirdPersonMoovement;
    public float speed = 0f;
    public int score;
    void Start()
    {
        score = 0;
        UpdateScore(0);
        animator = GetComponent<Animator>();
        SoundSheep = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (tirdPersonMoovement.isGameActive)
        {
            int nbSheep = listSheep.transform.childCount;
            Debug.Log("nbSheep = " + nbSheep);
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
            transform.LookAt(minPosSheep);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            SoundSheep.Play();
            animator.Play("Wolf_Attack");
            UpdateScore(5);
            Destroy(collision.gameObject);
        }
    }
    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreWolfText.text = "Wolf: " + score;
    }
}
