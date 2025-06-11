using UnityEngine;

public class PlayerFire2 : MonoBehaviour
{
    public GameObject bulletFactory;
    GameObject firePosition;
    GameObject firePosition2;
    GameObject firePosition3;

    AudioSource audioSource;
    public AudioClip bulletClip;

    float fireDelay = 1.0f;
    float lastFireTime = -999f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        firePosition = GameObject.Find("FirePosition");
        firePosition2 = GameObject.Find("FirePosition2");
        firePosition3 = GameObject.Find("FirePosition3");
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetButton("Fire1") && Time.time - lastFireTime >= fireDelay)
        {
            GameObject bullet = Instantiate(bulletFactory);
            GameObject bullet2 = Instantiate(bulletFactory);
            GameObject bullet3 = Instantiate(bulletFactory);
            
            bullet.transform.position = firePosition.transform.position;
            bullet2.transform.position = firePosition2.transform.position;
            bullet3.transform.position = firePosition3.transform.position;

            audioSource.PlayOneShot(bulletClip);

            lastFireTime = Time.time;
        }
    }
}
