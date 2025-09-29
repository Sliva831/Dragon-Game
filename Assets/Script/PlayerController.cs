using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость перемещения
    public float jumpForce = 5f; // Сила прыжка
    private Rigidbody2D rb; // Компонент Rigidbody2D
    public bool isGrounded; // Находится ли персонаж на земле

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
        
    {
        float horiz = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);

        //Поворачиваем персонажа в сторону движения
        if (horiz > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
       if (horiz < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //Прыжок
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse); //Прыжок
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

