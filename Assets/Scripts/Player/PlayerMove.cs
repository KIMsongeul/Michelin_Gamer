using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")] public float speed;
    [Header("Jump")] public float jumpPower;
    
    private HpSystem hpSystem;


    private bool isGround = true;

    private Rigidbody2D rigid;
    private Animator anim;
    
    
    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);
        anim.SetBool(AnimationStrings.MovementBool,horizontal != 0);
        
        
        //horizontal의 값에 따라 캐릭터 에셋의 방향 바꾸기
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
            isGround = false;
            
            anim.SetTrigger(AnimationStrings.JumpTrigger);
            anim.SetBool("IsGround",false);
            
        }
    }
    public void TakeDamage(float damage)
    {
        hpSystem.Damage(damage);
        if (hpSystem.curHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Jump();

        if (hpSystem.curHp <= 0)
        {
            Die();
        }
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        hpSystem = GetComponent<HpSystem>();
        hpSystem.SetHp(100);
        hpSystem.CheckHp();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            anim.SetBool("IsGround",true);
        }
    }
}
