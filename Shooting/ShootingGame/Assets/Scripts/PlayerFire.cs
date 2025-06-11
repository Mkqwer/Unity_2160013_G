using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    GameObject firePosition;
    GameObject firePosition2;

    AudioSource audioSource;
    public AudioClip bulletClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        firePosition = GameObject.Find("FirePosition");
        firePosition2 = GameObject.Find("FirePosition2");
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            GameObject bullet2 = Instantiate(bulletFactory);

            bullet.transform.position = firePosition.transform.position;
            bullet2.transform.position = firePosition2.transform.position;

            audioSource.PlayOneShot(bulletClip);
        }
    }
}
