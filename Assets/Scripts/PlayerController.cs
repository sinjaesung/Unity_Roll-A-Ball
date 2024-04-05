using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float minHeight;
    private Movement3D movement3d;

    private void Awake()
    {
        //github ���Ϻ��� �׽�Ʈ

        movement3d = GetComponent<Movement3D>();
    }

    private void Update()
    {
        //����Ű�� ������ �̵�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x != 0 || z != 0)
        {
            //(x,0,z) �������� �̵�
            movement3d.MoveTo(new Vector3(x, 0, z));
        }

        //���������� �÷��̾ ���������� üũ
        ChangeSceneFallDown();
    }

    private void ChangeSceneFallDown()
    {
        if(transform.position.y < minHeight)
        {
            //���� ���� �ε� (���� �� �����)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
