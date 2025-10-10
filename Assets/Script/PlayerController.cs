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
    private Animator anim; // Компонент Animator

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем Rigidbody2D
        anim = GetComponent<Animator>(); // Получаем Animator

    }

    // Update is called once per frame
    void Update()
        
    {
        Move();
        Jump();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump",false); // Диактивируем прыжок
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Move()
    {
        float horiz = Input.GetAxis("Horizontal"); //Получаем ввод с клавиатуры
        rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y); //Изменяем скорость по оси Х
        // Устанавливаем анимацию бега 
        anim.SetBool("walk",horiz !=0); // Передаем состояние бега в аниматор 

        //Поворачиваем персонажа в сторону движения
        if (horiz > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if (horiz < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }

    private void Jump()
    {
        //Прыжок
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Прыжок
            anim.SetBool("jump", true); // Активируем прыжок
        }
    }
}

