using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed;
    [Header("回転速度")]
    public float rotateSpeed;

    [Header("ジャンプ力")]
    public float jumpPower;
    [Header("地面判定用レイヤー")]
    public LayerMask groundLayer;

    public bool isGround;
    private Rigidbody rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    private void Jump()
    {
        isGround = Physics.Linecast(transform.position + transform.up * 1,
            transform.position - transform.up * 0.3f,
            groundLayer);
        if (Input.GetButtonDown("Jump") && isGround)
        {
            anim.SetTrigger("jump");
            isGround = false;
            rb.AddForce(Vector3.up * jumpPower);
        }
    }

}
