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
        //other 오브젝트의 태그가 "Player"이면
        if (other.CompareTag("Player"))
        {
            //other(플레이어)의 위치를 arrivePoint로 설정
            other.transform.position = arrivePoint.position;
        }
    }
}
