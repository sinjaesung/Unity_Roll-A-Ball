using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName; //���� �� �̸�
    [SerializeField]
    private GameObject panelStageClear; //�������� Ŭ���� �� ��Ÿ���� Panel UI
    private int maxCoinCount;
    private int currentCoinCount;
    private bool getAllCoins = false; //��� ���� ȹ�� �� true

    public int MaxCoinCount => maxCoinCount;
    public int CurrentCoinCount => currentCoinCount;


    private void Awake()
    {
        //�ð������� 1�� ������ ����ӵ��� ���
        Time.timeScale = 1.0f;
        //��� ������ ȹ������ �� ���� (panelStageClear ������Ʈ ��Ȱ��ȭ)
        panelStageClear.SetActive(false);

        // �±װ� Coin�� ������Ʈ�� ������ maxCoinCount�� ����(�ʿ� ��ġ�� ���ΰ���)
        maxCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        currentCoinCount = maxCoinCount;
    }

    private void Update()
    {
        //��� ������ ȹ������ ��
        if(getAllCoins == true)
        {
            //EnterŰ�� ������
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //nextSceneName ������ �̵�
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
    public void GetCoin()
    {
        //���� ������ ���� -1
        currentCoinCount--;

        //���� ������ ������ 0�̸�
        if(currentCoinCount == 0)
        {
            //��� ���� ȹ������ true
            getAllCoins = true;
            //�ð������� 0���� ������ �Ͻ�����
            Time.timeScale = 0.0f;
            //panelStageClear ������Ʈ Ȱ��ȭ
            panelStageClear.SetActive(true);
        }
    }
}
