using UnityEngine;
using UnityEngine.UI;

public class ChestNutGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    public float minPower = 1000f;
    public float maxPower = 3000f;
    public float chargeSpeed = 5000f;  // 왕복 속도
    private float currentPower = 0f;

    private bool isCharging = false;
    private bool isPowerIncreasing = true;

    public Slider powerSlider;

    void Start()
    {
        if (powerSlider != null)
        {
            powerSlider.minValue = minPower;
            powerSlider.maxValue = maxPower;
            powerSlider.value = minPower;
        }

        currentPower = minPower;
    }

    void Update()
    {
        // 마우스 버튼 누르면 왕복 충전 시작
        if (Input.GetMouseButtonDown(0) && GameManager.instance.isLive)
        {
            isCharging = true;
            isPowerIncreasing = true; // 시작은 증가 방향
        }

        if (isCharging)
        {
            // 왕복 충전 로직
            float delta = chargeSpeed * Time.deltaTime;

            if (isPowerIncreasing)
            {
                currentPower += delta;
                if (currentPower >= maxPower)
                {
                    currentPower = maxPower;
                    isPowerIncreasing = false;
                }
            }
            else
            {
                currentPower -= delta;
                if (currentPower <= minPower)
                {
                    currentPower = minPower;
                    isPowerIncreasing = true;
                }
            }

            // UI 반영
            if (powerSlider != null)
            {
                powerSlider.value = currentPower;
            }
        }

        // 버튼 뗄 때 발사
        if (Input.GetMouseButtonUp(0) && isCharging && !GameManager.instance.isShoot)
        {
            Fire(currentPower);
            isCharging = false;
            currentPower = minPower;

            // UI 초기화
            if (powerSlider != null)
            {
                powerSlider.value = minPower;
            }

            GameManager.instance.throwChestNutNum--;
        }
    }

    void Fire(float power)
    {
        Camera cam = Camera.main;
        Vector3 spawnPos = cam.transform.position + cam.transform.forward * 1.0f;

        GameObject bamsongi = Instantiate(bamsongiPrefab, spawnPos, Quaternion.identity);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction;

        bamsongi.GetComponent<ChestNutBehavior>().Shoot(worldDir.normalized * power);
    }
}
