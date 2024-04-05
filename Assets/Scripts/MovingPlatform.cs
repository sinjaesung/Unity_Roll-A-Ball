using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints; //�̵� ������ ����
    [SerializeField]
    private float waitTime; //wayPoint ���� �� ���ð�
    [SerializeField]
    private float moveSpeed; //�̵� �ӵ�
    private int wayPointCount; //�̵� ������ wayPoint ����
    private int currentIndex = 0; //���� wayPoint �ε���

    private void Awake()
    {
        wayPointCount = wayPoints.Length;
        //���� ������Ʈ ��ġ ����
        transform.position = wayPoints[currentIndex].position;

        currentIndex++;

        StartCoroutine("MoveTo");
    }

    private IEnumerator MoveTo()
    {
        while (true)
        {
            //wayPoints[currentState].position���� �̵�
            yield return StartCoroutine("Movement");

            //waitTime�ð� ���� ���
            yield return new WaitForSeconds(waitTime);

            //���� ��������Ʈ ����
            if(currentIndex < wayPointCount - 1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0; //������ wayPoint�̸� ù ��° wayPoint�� ����
            }
        }
    }

    private IEnumerator Movement()
    {
        while (true)
        {
            //��ǥ ��ġ�� ���� �̵� ���� = ��ǥ ��ġ - �� ��ġ(normalized�� ������ ������ �ּ��� �ӵ��� ����)
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            //������Ʈ �̵� (����*�ӵ�*Time.deltaTime)
            transform.position += direction * moveSpeed * Time.deltaTime;

            //��ǥ ��ġ�� ���� �������� �� (���� ��ġ�� ��ǥ ��ġ�� �Ÿ� ���� 0.1�̸�)
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.1f)
            {
                //���� ��ġ�� ��ǥ ��ġ�� �����ϰ� ����
                transform.position = wayPoints[currentIndex].position;
                //�̵� ����
                break;
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //�÷��̾� ������Ʈ�� �÷����� �ڽ����� ����
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //�÷��̾� ������Ʈ�� �÷����� �ڽĿ��� ����
            collision.transform.SetParent(null);
        }
    }
}
