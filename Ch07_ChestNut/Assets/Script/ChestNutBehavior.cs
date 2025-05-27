using TMPro;
using UnityEngine;

public class ChestNutBehavior : MonoBehaviour
{

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
        GameManager.instance.isShoot = true;
        //쏘자마자 다시 쏘지 않기 위한 Bool변수
        Invoke("ShootOut", 5f);
        //사격 쿨타임 : 5초로 지정
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        //Shoot(new Vector3(0, 200, -2000));


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            GameManager.instance.isHit = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();
            GameManager.instance.score++;

        }
    }



    void ShootOut()
    {
        GameManager.instance.isShoot = false;
    }
}
