using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Level : MonoBehaviour

{
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void CountScene()
    {
        SceneManager.LoadScene("CountScene");
    }

}