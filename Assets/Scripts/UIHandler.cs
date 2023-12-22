using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
