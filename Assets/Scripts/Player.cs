using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ����ٶ�
    [Range(0, 50)]
    public float playerSpeed;
    // ��ҽ���ֵ
    [Range(100, 500)]
    public int playerHealth;
    // �������
    public Vector3 playerInput;

    // ��Ҷ���
    Animator playerAnimator;
    // ����޲���ʱ��
    float noInputTime;

    // ����ٻ��Ｐ����λ��
    public GameObject summonedObject;
    Vector3 Position;
    Vector3 Rotation;

    void Start()
    {
        // ����Ҷ���
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // �����޲���ʱ��
        noInputTime = (noInputTime > 5.0f) ? 5.0f : (noInputTime + Time.deltaTime);
        // ����Animator��noInput����
        playerAnimator.SetFloat("noInput", noInputTime);

        // �ո�������ٻ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(summonedObject, transform.position, Quaternion.identity);
        }

        // ����״̬���е�isRunning���Դ����ƶ���վ������
        if (playerInput != Vector3.zero)
        {
            playerAnimator.SetBool("isRunning", true);
            noInputTime = 0;
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }

        // ��ҵ��ƶ�����
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += playerInput * playerSpeed * Time.deltaTime;
    }
}
