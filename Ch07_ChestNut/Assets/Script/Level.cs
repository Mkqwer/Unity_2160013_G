using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Level : MonoBehaviour
    //씬 매니저를 이용한 씬 이동 전환 담당 클래스
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
        GameManager.instance.throwChestNutNum = -1;
    }

    public void CountScene()
    {
        SceneManager.LoadScene("CountScene");
    }

}