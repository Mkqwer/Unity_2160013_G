using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject tutorialWall1;
    public GameObject tutorialWall2;

    public int score = 0;

    float maxGameTime = 30f;
    float curGameTime = 0f;

    int maxHealth = 3;
    int culHealth = 0;

    float curPower = 0f;
    float maxPower = 3f;

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

}
