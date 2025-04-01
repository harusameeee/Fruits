using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ToPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void ToResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void ToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void ToSelectScene()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void EndGame()
    {
        Application.Quit();
    }


}
