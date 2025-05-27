/*
 * 화살 오브젝트를 1초에 한 개씩 생성하는 알고리즘
 * Update 메서드는 프레임마다 실행되고 앞 프레임과 현재 프레임의 사이의 시간 차이는 Time. deltaTime에 대입
 *- 대나무 동을 비우는 시점인 1초에 한 번씩 화살이 생성됨
 *Instantiate 메서드
 *--게임을 실행하는 도중에 게임오브젝트를 생성할수 있음
 *--화살 프리팹을 이용하여, 화살 인스턴스를 생성하는 메서드
 *-Random.Range 메서드: 랜덤 값을 쉽게 생성할 수 있는 방법
 *-Random 클래스는 흔히 요구되는 다양한 타입의 랜덤 값을 쉽게 생성 할 수 있는 방법을 제공
 *--사용자가 제공한 최솟값과 최댓값 사이의 임의의 숫자를 제공함
 *  --첫번째 매개변수보다 크거나 같고 두 번째 매개변수보다 작은 범위에서 무작위 수를 랜덤하게 반환
 */


using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject garrowPrefab = null; //화살 Prefab을 넣을 빈오브젝트 상자 선언

    GameObject gArrowInstance = null;   //화살 인스턴스 저장 변수

    float fArrowCreateSpan = 1.0f;  //화살 생성 변수 : 화살을 1초마다 생성 변수
    float fDeltaTime = 0.0f;    //앞 프레임과 현재 프레임 사이의 시간 차이를 저장하는 변수

    int nArrowPositionRance = 0;    //화살의 X 좌표 Range 저장 변수

    void Update()
    {
        fDeltaTime  += Time.deltaTime;
        if (fDeltaTime > fArrowCreateSpan)
        {
            fDeltaTime = 0.0f;

            /*
             * Instantiate 메서드: 화살 프리팹을 이용하여, 화살 인스턴스를 생성하는 메서드
             * -매개변수로 프리팹을 전달하면, 반환값으로 프리팹 인스턴스를 돌려준다
             * Instatiate 메서드를 사용하면 게임을 실행하는 도중에 게임오브젝트를 생성할 수 있음
             * RPG 게임이라면 수많은 아이템, 캐릭터, 배경 등 모든것들을 어떻게 미리 만들어 놓을수있을까?
             *  그러므로 게임오브젝트의 복제본을 생성
             *  - Instatiate(GameObject original, Vector3 position, Quaternion rotation)
             *  -- Object original : 생성하고자 하는 게임 오브젝트명, 현재 씬에 있는 게임 오브젝트나 Prefab으로 선언되 객체를 의미함
             *  -- Vector3 position : Vector3으로 생성될 위치를 설정함
             *  -- Quatenion rotation: 생성될 게임오브제그의 회전값을 지정
             */

            gArrowInstance = Instantiate(garrowPrefab);

            /*
             * Random 클래스는 흔히 요구되는 다양한 타입의 랜덤 값을 쉽게 생성할 수 있는 방법을 제공
             * Random.Range 메서드: 사용자가 제공한 최솟값과 최대값 사이의 임의의 숫자를 제공함
             * -제공된 최솟값과 최댓값이 정수인지 실수인지에 따라 정수 또는 실수를 반환함
             * -화살의 X좌표는 -6 ~ 6사이에 불규칙하게 위치
             */

            nArrowPositionRance = Random.Range(-6, 7);
            gArrowInstance.transform.position = new Vector3(nArrowPositionRance, 7, 0);
        }
    }
}
