using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Health playerHealth;
    public Image totalHeart;
    public Image currentHeart;

    // Start is called before the first frame update
    void Start()
    {
        totalHeart.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHeart.fillAmount = playerHealth.currentHealth / 10;
    }
}
