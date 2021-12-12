using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public void NewScenes1 (string Easy)
    {
        SceneManager.LoadScene(Easy);
    }
    public void NewScenes2 (string Normal)
    {
        SceneManager.LoadScene(Normal);
    }
    public void NewScenes3(string Hard)
    {
        SceneManager.LoadScene(Hard);
    }
    public Text Titre = null;

    public void Exit()
    {
        Application.Quit();
    }

}
