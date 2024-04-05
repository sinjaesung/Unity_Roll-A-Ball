using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private GameObject coinEffectPrefab;
    private float rotateSpeed = 100.0f;

    private void Update()
    {
        //���� ������Ʈ ȸ��
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //���� ������Ʈ ȹ�� ȿ��(coinEffectPrefab) ����
        GameObject clone = Instantiate(coinEffectPrefab);
        clone.transform.position = transform.position;

        //���� ȹ�� �� ó��
        stageController.GetCoin();

        //���� ������Ʈ ����
        Destroy(gameObject);
    }
}
