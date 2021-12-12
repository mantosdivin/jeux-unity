using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public void EasyButton(string Easy)
    {
        SceneManager.LoadScene(Easy);
    }
    public void MediumButton(string Medium)
    {
        SceneManager.LoadScene(Medium);
    }
    public void HardButton(string Hard)
    {
        SceneManager.LoadScene(Hard);
    }
    public Text Titre = null;

    public void Exit()
    {
        Application.Quit();
    }

}
