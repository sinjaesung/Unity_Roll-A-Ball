using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform arrivePoint;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //other ������Ʈ�� �±װ� "Player"�̸�
        if (other.CompareTag("Player"))
        {
            //other(�÷��̾�)�� ��ġ�� arrivePoint�� ����
            other.transform.position = arrivePoint.position;
        }
    }
}
