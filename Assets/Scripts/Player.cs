using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 玩家速度
    [Range(0, 50)]
    public float playerSpeed;
    // 玩家健康值
    [Range(100, 500)]
    public int playerHealth;
    // 玩家输入
    public Vector3 playerInput;

    // 玩家动画
    Animator playerAnimator;
    // 玩家无操作时间
    float noInputTime;

    // 玩家召唤物及放置位置
    public GameObject summonedObject;
    Vector3 Position;
    Vector3 Rotation;

    void Start()
    {
        // 绑定玩家动画
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // 更新无操作时间
        noInputTime = (noInputTime > 5.0f) ? 5.0f : (noInputTime + Time.deltaTime);
        // 更新Animator的noInput属性
        playerAnimator.SetFloat("noInput", noInputTime);

        // 空格键放置召唤物
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(summonedObject, transform.position, Quaternion.identity);
        }

        // 设置状态机中的isRunning，以触发移动和站立动画
        if (playerInput != Vector3.zero)
        {
            playerAnimator.SetBool("isRunning", true);
            noInputTime = 0;
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }

        // 玩家的移动代码
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.position += playerInput * playerSpeed * Time.deltaTime;
    }
}
