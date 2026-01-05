using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
    }
}