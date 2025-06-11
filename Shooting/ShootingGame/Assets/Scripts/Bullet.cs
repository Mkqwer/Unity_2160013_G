using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        Destroy(gameObject, 6f);
    }
}