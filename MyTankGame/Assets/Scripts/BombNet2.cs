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
        Invoke("killBombRpc", 4.0f); // 4�� �ڿ� killBombRpc() ȣ���ؼ� ��ź�� �ı�
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

    [Rpc(SendTo.Server)] // Despawn()�� server RPC�� ����
    void killBombRpc()
    {
        NetworkObject.Despawn(); // Despawn()�� Spawn()�� �ݴ븻: ������ de�� ���شٴ� ��
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���� ��ġ�� BombYellow(tag = Bomb2) 
        string tag = collision.gameObject.tag; // �浹�� ���ü�� tag
        if (tag == "Plane") // ���� �ε���
        {
            makeExplosionRpc();
            killBombRpc();
        }
        else if (tag == "Player") // ���� ��ũ�� �浹
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
        // prefab�� ���� �����(instantiate)
        GameObject prefab = Instantiate(prefabFile);
        prefab.transform.position = transform.position;
        prefab.transform.rotation = transform.rotation;
    }

}
