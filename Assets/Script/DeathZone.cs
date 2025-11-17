using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Tooltip("Точка возрождения игрока")]
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Если коснулся игрок — телепортируем его
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;

            // Сбрасываем скорость Rigidbody2D игрока
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}