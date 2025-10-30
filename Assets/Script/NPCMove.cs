using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public float walkDistance = 3f;
    public float speed = 2f;

    private float startX;
    private bool movingRight = true;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        startX = transform.position.x;
    }

    void Update()
    {
        // Определяем цель движения
        float targetX = movingRight ? startX + walkDistance : startX - walkDistance;

        // Двигаемся
        float newX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Поворачиваем спрайт
        sprite.flipX = !movingRight;

        // Проверяем дошли ли до края
        if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
        {
            movingRight = !movingRight;
        }
    }
}