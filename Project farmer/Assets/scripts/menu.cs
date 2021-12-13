using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public bool dontDestroy;
    public static int diffitculty = 0;
    private void Start()
    {
        Debug.Log("valeur difficutlé" + menu.diffitculty);
        if(dontDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
    public void EasyButton(string Easy)
    {
        diffitculty = 2;
        SceneManager.LoadScene(Easy);
    }
    public void MediumButton(string Medium)
    {
        diffitculty = 3;
        SceneManager.LoadScene(Medium);
    }
    public void HardButton(string Hard)
    {
        diffitculty = 4;
        SceneManager.LoadScene(Hard);
    }
    public Text Titre = null;


}
