using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPos;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Создаем пулю
            GameObject newBullet = Instantiate(bullet, shotPos.transform.position, transform.rotation);
            // Получаем скрипт пули
            Bullet bulletScript = newBullet.GetComponent<Bullet>();

            // Определяем направление (смотрим вправо или влево)
            if (transform.localScale.x > 0 )
            {
            bulletScript.direction = 1; // вправо
            }else
            {
                bulletScript.direction = -1;
            }
        }
    }
}
