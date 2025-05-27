using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //게에 사용할 게임 오브젝트 관리
    public GameObject tutorialWall1;
    public GameObject tutorialWall2;

    public GameObject finalScoreText;
    public GameObject retryButton;
    public GameObject mainMenuButton;
    public GameObject powerSlider;
    public GameObject powerText;

    public int throwChestNutNum = 0;

    public int score = 0;
    public bool isShoot = false;
    public bool isHit = false;

    public bool isLive = true;


    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       

    }


    void Start()
    {
        throwChestNutNum = PlayerPrefs.GetInt("ThrowCount", 0);  // 저장된 값 불러오기
    }

    void Update()
    {

        if (throwChestNutNum == 0)
        {
            Invoke("GameOver", 3f);
        }
    }

    void GameOver()
    {
        isLive = false;
        SceneManager.LoadScene("GameOverScene");
    }
    public void EnableWall1()
    {
        tutorialWall1.SetActive(true);
    }

    public void EnableWall2()
    {
        tutorialWall2.SetActive(true);
    }

    public void DisableWall1()
    {
        tutorialWall1.SetActive(false);
    }

    public void DisableWall2()
    {
        tutorialWall2.SetActive(false);
    }

    public void RetryFun()
    {
        SceneManager.LoadScene("GameScene");

    }

    public void MainMenuFun()
    {
        SceneManager.LoadScene("LevelScene");
        GameManager.instance.throwChestNutNum = 0;
    }


    
}
