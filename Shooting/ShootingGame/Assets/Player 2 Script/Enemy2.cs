using NUnit.Framework;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 5;

    Vector3 dir;
    GameObject player2;

    AudioSource audioSource;
    public AudioClip explosionClip;

    public GameObject explosionFactory;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        int rndValue = Random.Range(0, 10);
        player2 = GameObject.Find("Player2");

        if (rndValue <= 3)
        {
            dir = player2.transform.position - transform.position;
            dir.Normalize();
        }
        else { dir = Vector3.down; }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameManager2.Instance.SetScore();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag != "Item")
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            audioSource.PlayOneShot(explosionClip);
            Destroy(gameObject);
        }
    }
}
