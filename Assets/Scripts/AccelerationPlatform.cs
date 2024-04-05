using UnityEngine;

public class AccelerationPlatform : MonoBehaviour
{
    [SerializeField]
    private float accelForce;
    [SerializeField]
    private Vector3 direction;

    private void Awake()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //발판에 부딪힌 오브젝트(플레이어)에게 방향(direction)과 힘(accelForce) 전달
            collision.transform.GetComponent<Movement3D>().MoveTo(direction, accelForce);
        }
    }
}
