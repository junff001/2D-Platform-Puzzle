using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rigid;

    // 플레이어 무브 변수
    private float move; // 캐싱
    private bool jump; // 캐싱
    private bool isJump; // on/off

    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpPower = 5f;

    // 땅 체크 변수
    [Header("Ground Checking")]
    private bool isGround;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // PlayerInput 변수 캐싱
        move = input.move;
        jump = input.jump;
        if (jump) { // Update 와 FixedUpdate 의 생명주기 조율
            isJump = true;
        }

        Filp(); // 스프라이트 뒤집기
    }

    void FixedUpdate()
    {
        Move(); // 플레이어 이동
        Jump(); // 플레이어 점프

        isJump = false;        
    }

    private void Move()
    {      
        rigid.velocity = new Vector2(move * moveSpeed, rigid.velocity.y);
    }

    private void Jump()
    {
        if (isGround && isJump) {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    private void Filp()
    {
        if (move > 0) {
            transform.localScale = new Vector2(1, transform.localScale.y);
        } else if (move < 0) {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGround = false;
        }
    }
}
