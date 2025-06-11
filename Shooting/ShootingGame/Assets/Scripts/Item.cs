using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed = 5f;
    public GameObject explosionFactory;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Item taged {collision.gameObject.tag}");

        if (collision.gameObject.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}