using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour  
{   
    // 아직 버그 수정 안함 - 2021-12-07
    [SerializeField]
    private PlayerInput input;

    void Update()
    {
        if (input.jump) {
            input.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            collision.transform.SetParent(transform);
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            collision.transform.SetParent(null);
        }
    }
}
