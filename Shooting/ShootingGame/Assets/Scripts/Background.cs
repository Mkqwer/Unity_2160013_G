using UnityEngine;

public class Background : MonoBehaviour
{
    public Material bgMaterail;

    public float scrollSpeed = 0.2f;

    void Update()
    {
        bgMaterail.mainTextureOffset += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}
