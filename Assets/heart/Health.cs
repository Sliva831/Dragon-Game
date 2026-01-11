using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    private Animator anim;
    public bool dead = false;
    // Start is called before the first frame update

    public float iframesDuration;
    public int numberOfFlashes;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0, startingHealth);

        if(currentHealth > 0)
        {
            StartCoroutine(Flashes()); 
        }
        if(currentHealth <= 0)
        {
            
            dead = true;
            GetComponent <PlayerController>().enabled = false;
        }

    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator Flashes()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {

            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframesDuration / (numberOfFlashes * 2)); // 2/(5*2) = 2/10 = 0.2с
                                                                                      // 0.2с красный + 0.2с белый = 0.4с  5 морг. * 0.4с = 2с
                                                                                      
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iframesDuration / (numberOfFlashes * 2));

        }
        Physics2D.IgnoreLayerCollision(10, 11, false);



    }
}
