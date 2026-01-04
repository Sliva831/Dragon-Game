using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class turrelWeapon : MonoBehaviour
{
    [Header("Настройка стрельбы")]
    public Transform shotPos;
    public GameObject bullet;
    public float firetime = 3f; // время выстрела
    public Vector2 shootDirection = Vector2.left; // направление выстрела 

    private float nextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        // нормализуем направление на всякий случай 
        //shootDirection = shootDirection.normalized;

        // Поварачиваем турель в направлении стрельбы
        //float angle = Mathf.Atan2(shootDirection.y, shootDirection.x)*Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime) {
            Shoot();
            nextFireTime = Time.time + 1f / firetime;
        }

    }

    void Shoot()
    {
        Instantiate(bullet,shotPos.position,shotPos.rotation);
    }
}
