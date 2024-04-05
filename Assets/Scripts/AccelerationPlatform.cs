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
            //���ǿ� �ε��� ������Ʈ(�÷��̾�)���� ����(direction)�� ��(accelForce) ����
            collision.transform.GetComponent<Movement3D>().MoveTo(direction, accelForce);
        }
    }
}
