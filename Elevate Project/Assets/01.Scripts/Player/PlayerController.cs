using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rigid;
    SpriteRenderer sprite;

    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpPower = 5f;
    private float move;
    private bool jump;
    private bool isJump;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        move = input.move;
        jump = input.jump;
        Move();  // 플레이어 이동
        Jump();  // 플레이어 점프
        Filp();  // 스프라이트 뒤집기
    }

    private void Move()
    {      
        rigid.velocity = new Vector2(move * moveSpeed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isJump = false;
        }
    }

    private void Jump()
    {
        if (isJump && jump) {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void Filp()
    {
        if (move > 0) {
            sprite.flipX = false;
        } else if (move < 0) {
            sprite.flipX = true;
        }
    }
}
