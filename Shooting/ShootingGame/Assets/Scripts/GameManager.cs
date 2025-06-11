using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text bestScoreUI;
    int bestScore;

    public Text currentScoreUI;
    public int getScore = 1;
    int currentScore;

    public Text lifeUI;
    PlayerHeart life;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        life = GameObject.Find("Player").GetComponent<PlayerHeart>();
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score");
        bestScoreUI.text = $"Best Score : {bestScore}";
        Debug.Log($"Best Score : {bestScore}");

        currentScoreUI.text = $"Current Score : {currentScore}";

        lifeUI.text = $"Life : {life.heart}";
    }

    public void SetScore()
    {
        currentScore += getScore;
        currentScoreUI.text = $"Current Score : {currentScore}";

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            bestScoreUI.text = $"Best Score : {bestScore}";
            PlayerPrefs.SetInt("Best Score", bestScore);
            PlayerPrefs.Save();
        }
    }

    public void SetHeart(string tag)
    {
        if (tag == "Item")
        {
            if (life.heart < life.maxHeart) { life.heart += life.getHeart; }
        }

        if (tag == "Enemy") { life.heart -= life.getHeart; }

        lifeUI.text = $"Life : {life.heart}";
    }

    public void GameOver()
    {
        if (life.heart == 0) { SceneManager.LoadScene("GameOver"); }
    }
}
