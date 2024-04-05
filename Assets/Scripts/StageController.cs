using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName; //다음 씬 이름
    [SerializeField]
    private GameObject panelStageClear; //스테이지 클리어 시 나타나는 Panel UI
    private int maxCoinCount;
    private int currentCoinCount;
    private bool getAllCoins = false; //모든 코인 획득 시 true

    public int MaxCoinCount => maxCoinCount;
    public int CurrentCoinCount => currentCoinCount;


    private void Awake()
    {
        //시간배율을 1로 설정해 정상속도로 재생
        Time.timeScale = 1.0f;
        //모든 코인을 획득했을 때 등장 (panelStageClear 오브젝트 비활성화)
        panelStageClear.SetActive(false);

        // 태그가 Coin인 오브젝트의 개수를 maxCoinCount에 저장(맵에 배치된 코인개수)
        maxCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        currentCoinCount = maxCoinCount;
    }

    private void Update()
    {
        //모든 코인을 획득했을 때
        if(getAllCoins == true)
        {
            //Enter키를 누르면
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //nextSceneName 씬으로 이동
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
    public void GetCoin()
    {
        //현재 코인의 개수 -1
        currentCoinCount--;

        //현재 코인의 개수가 0이면
        if(currentCoinCount == 0)
        {
            //모든 코인 획득으로 true
            getAllCoins = true;
            //시간배율을 0으로 설정해 일시정지
            Time.timeScale = 0.0f;
            //panelStageClear 오브젝트 활성화
            panelStageClear.SetActive(true);
        }
    }
}
