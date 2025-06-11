using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public StageData stageData;
    public float speed = 5;

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.limitMin.x, stageData.limitMax.x), Mathf.Clamp(transform.position.y, stageData.limitMin.y, stageData.limitMax.y));
    }
}
