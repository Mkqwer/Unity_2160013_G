using UnityEngine;

public class RotateWall : MonoBehaviour
{
    public float speed = 1.0f;  // 벽이 움직이는 속도

    private int direction = 1;  // 1이면 오른쪽 -1이면 왼쪽

    void Start()
    {
       
    }

    void Update()
    {

        if (this.gameObject.tag == "MovingWall")
        {
            Move();
        }

        

    }

    void Move()
    {
        {
            // 벽 움직임
            transform.Rotate(Vector3.forward * direction * speed * Time.deltaTime);
        }
    }
}
