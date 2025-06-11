using UnityEngine;

public class PlayerHeart2 : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip explosionClip;

    public int maxHeart = 3;
    public int getHeart = 1;

    internal int heart;
    float delta = 1f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        heart = maxHeart;
    }

    void Update()
    {
        HeartTest();
        HeartRotate();
        GameManager2.Instance.GameOver();
    }

    void HeartRotate()
    {
        if (heart == maxHeart)
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

        if (heart < maxHeart)
        {
            if (heart == 1) { delta = 2f; }
            transform.Rotate(0, 0, 30 * delta * Time.deltaTime);
        }
    }

    void HeartTest()
    {
        if (Input.GetKeyDown(KeyCode.R)) { GameManager2.Instance.SetHeart("Enemy"); }
        if (Input.GetKeyDown(KeyCode.T)) { GameManager2.Instance.SetHeart("Item"); }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Player taged {collision.gameObject.tag}");
        if (collision.gameObject.tag == "Enemy") { audioSource.PlayOneShot(explosionClip); }
        GameManager2.Instance.SetHeart(collision.gameObject.tag);
    }
}
