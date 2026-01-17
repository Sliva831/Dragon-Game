using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    private Animator anim;
    public bool dead = false;

    public float iframesDuration;
    public int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    // ”кажи длительность анимации смерти в секундах
    public float deathAnimationDuration = 0.6f;

    // —сылка на панель смерти (должна быть в Canvas!)
    public GameObject deathPanel;

    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (anim == null)
            Debug.LogError("Animator не найден на " + name);

        if (deathPanel != null)
            deathPanel.SetActive(false);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            StartCoroutine(Flashes());
        }
        else if (!dead)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;

        if (anim != null)
            anim.SetBool("IsDead", true);

        PlayerController pc = GetComponent<PlayerController>();
        if (pc != null)
            pc.enabled = false;

        // «апускаем корутину: подождать анимацию ? показать меню
        StartCoroutine(ShowDeathMenuAfterDelay(deathAnimationDuration));
    }

    IEnumerator ShowDeathMenuAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // игнорирует Time.timeScale!

        // ќстанавливаем врем€ (если ещЄ не остановлено)
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;

        if (deathPanel != null)
        {
            deathPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("deathPanel не назначена в инспекторе!");
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
            yield return new WaitForSeconds(iframesDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iframesDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}