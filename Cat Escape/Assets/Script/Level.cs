using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Main()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
