using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하므로 잊지 않고 추가

public class GameDirector : MonoBehaviour
{
    GameObject ghpGauge;
    public GameObject _GameOver;
 
    public static GameDirector instance = null; // 다른스크립트에서 참조하기위한 인스턴스화

    public bool _isDead = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        /*
         * 각 오브젝트 상자에 대응하는 오브젝트를 씬 안에서 찾아 넣어야 함
         * 씬 안에서 오브젝트를 찾는 메서드: Find
         * 인수 이름이 씬에 존재하면 해당 오브젝트를 
         */
        this.ghpGauge = GameObject.Find("hpGauge");
        //this.GameOver = GameObject.Find("GameOver");
    }

    /*
     * 나중에 화살 컨트롤러에서 HP 게이지 표시를 줄이는 처리를 호출할 것을 고려해
     * 화살과 플레이어가 충돌했을 때 화살 컨트롤러가 f_DecreaseHp() 메서드를 호출함
     * 메서드의 기능은 화살과 플레이어가 충돌했을 때 Image 오브젝트(hpGauge)의 fillAmount를 줄여
     * HP게이지를 표시하는 비율을 10%씩 낮춤
     */
    public void f_DecreaseHp()
    {
        /*
         * 유니티 프로젝트는 GameObjrct라는 빈 상자에 설정 자료(컴퍼넌트)를 추가해서 기능을 확장함
         * (예) 오브젝트를 물리적으로 움직이게 하려면 Rigidbody 컴퍼넌트 추가
         * (예) 소리를 내게 하려면AudioSource컴퍼넌트 추가
         * (예) 자체 기능을 늘리고 싶다면 컴퍼넌트를 추가함
         * 컴퍼넌트 접근 방법: GetComponent는 게임 오브젝트에 대해 'oo컴포넌트를 주세요'라고 부탁하면
         * 해당되는 컴퍼넌트(기능)을 돌려주는 메서드
         * (예)AudioSource컴퍼넌트를 원하면 -> GetCommponent<)AudioSource>()
         * (예)Text컴퍼넌트를 원하면 ->  GetComponent<Text>()
         * (예) 직접 만든 스크립트도 컴퍼넌트의 일종이므로 GetComponent 메서드를 사용해서 구할 수 있음
         */

        //화살과 플레이어가 충돌했을때 Image 오브젝트(hpGauge)의 fillAmount를 줄여
        this.ghpGauge.GetComponent<Image>().fillAmount -= 0.1f;

        if (this.ghpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        _isDead = true;
        _GameOver.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameStart()
    {
        _isDead = false;
        Time.timeScale = 1;
    }
}
