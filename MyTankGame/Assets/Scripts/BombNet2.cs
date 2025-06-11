using UnityEngine;
using Unity.Netcode;

public class BombNet2 : NetworkBehaviour
{
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!IsOwner) return;
        rb = GetComponent<Rigidbody>();
        shotBombRpc();
        Invoke("killBombRpc", 4.0f); // 4초 뒤에 killBombRpc() 호출해서 포탄을 파괴
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Rpc(SendTo.Owner)]
    void shotBombRpc()
    {
        rb.AddForce(transform.up * GameManager.Instance.ForceBomb);
    }

    [Rpc(SendTo.Server)] // Despawn()은 server RPC만 가능
    void killBombRpc()
    {
        NetworkObject.Despawn(); // Despawn()은 Spawn()의 반대말: 영어의 de는 없앤다는 뜻
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 현재 위치는 BombYellow(tag = Bomb2) 
        string tag = collision.gameObject.tag; // 충돌한 대상체의 tag
        if (tag == "Plane") // 땅에 부딪힘
        {
            makeExplosionRpc();
            killBombRpc();
        }
        else if (tag == "Player") // 상대방 탱크에 충돌
        {
            collision.gameObject.GetComponent<PlayerHealthNet>().decHealthRpc2();
            makeExplosionRpc();
            killBombRpc();
        }
 
    }


    [Rpc(SendTo.Server)]
    void makeExplosionRpc()
    {
        GameObject prefabFile = Resources.Load("Explosion_3_Skull_Yellow") as GameObject;
        // prefab의 예시 만들기(instantiate)
        GameObject prefab = Instantiate(prefabFile);
        prefab.transform.position = transform.position;
        prefab.transform.rotation = transform.rotation;
    }

}
