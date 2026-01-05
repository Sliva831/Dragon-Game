using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private DeathZone respawn;
    private BoxCollider2D checkPointCollider;

    // Start is called before the first frame update
    void Start()
    {
        checkPointCollider = GetComponent<BoxCollider2D>();

        GameObject respawnObject = GameObject.FindGameObjectWithTag("DeathZone");
        if(respawnObject != null )
        {
            respawn = respawnObject.GetComponent<DeathZone>();
            Debug.Log("Yes");
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
            checkPointCollider.enabled = false;
        }
    }
}
