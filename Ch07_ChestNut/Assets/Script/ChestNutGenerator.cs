using UnityEngine;
using UnityEngine.UI;

// 밤송이를 생성하고 발사하는 기능을 담당하는 클래스
public class ChestNutGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;         // 발사할 밤송이 프리팹
    public float minPower = 1000f;            // 최소 파워 값
    public float maxPower = 3000f;            // 최대 파워 값
    public float chargeSpeed = 5000f;         // 충전 속도 (왕복 속도)
    private float currentPower = 0f;          // 현재 충전된 파워

    private bool isCharging = false;          // 현재 충전 중인지 여부
    private bool isPowerIncreasing = true;    // 파워가 증가 중인지 감소 중인지 여부

    public Slider powerSlider;                // UI 파워 슬라이더

    void Start()
    {
        // 슬라이더가 존재하면 초기값 설정
        if (powerSlider != null)
        {
            powerSlider.minValue = minPower;
            powerSlider.maxValue = maxPower;
            powerSlider.value = minPower;
        }

        currentPower = minPower; // 시작 시 최소 파워로 초기화
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 누르면 충전 시작 (쏠 환경이 충족됐을때 적용)
        if (Input.GetMouseButtonDown(0) && GameManager.instance.isLive&& !GameManager.instance.isShoot)
        {
            isCharging = true;
            isPowerIncreasing = true; // 처음엔 증가 방향부터 시작
        }

        if (isCharging)
        {
            // 충전 로직 (파워를 왕복 증가/감소)
            float delta = chargeSpeed * Time.deltaTime;

            if (isPowerIncreasing)
            {
                currentPower += delta;
                if (currentPower >= maxPower)
                {
                    currentPower = maxPower;
                    isPowerIncreasing = false; // 최대치 도달시 감소로 전환
                }
            }
            else
            {
                currentPower -= delta;
                if (currentPower <= minPower)
                {
                    currentPower = minPower;
                    isPowerIncreasing = true; // 최소치 도달시 증가로 전환
                }
            }

            // 슬라이더 UI에 현재 파워 값 반영
            if (powerSlider != null)
            {
                powerSlider.value = currentPower;
            }
        }

        // 마우스 왼쪽 버튼을 뗐을 때 발사 (발사된 상태가 아닐 시)
        if (Input.GetMouseButtonUp(0) && isCharging && !GameManager.instance.isShoot)
        {
            Fire(currentPower); // 현재 파워로 발사
            isCharging = false; // 충전 종료
            currentPower = minPower; // 파워 초기화

            // UI 초기화
            if (powerSlider != null)
            {
                powerSlider.value = minPower;
            }
            // 발사 횟수 감소
            GameManager.instance.throwChestNutNum--;
        }
    }

    // 밤송이를 발사하는 메서드
    void Fire(float power)
    {
        Camera cam = Camera.main;
        // 카메라 앞에 생성
        Vector3 spawnPos = cam.transform.position + cam.transform.forward * 1.0f; 

        // 밤송이 프리팹 인스턴스화
        GameObject bamsongi = Instantiate(bamsongiPrefab, spawnPos, Quaternion.identity);

        // 마우스 위치 기준으로 방향 설정
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction;

        // 지정된 방향과 힘으로 발사
        bamsongi.GetComponent<ChestNutBehavior>().Shoot(worldDir.normalized * power);
    }
}
