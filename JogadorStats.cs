using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JogadorStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float playerLevel = 0;

    public Slider healthBar;

    private Coroutine regenHealth;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    [SerializeField]
    private int timeBeforeRegenHealth = 5;
    [SerializeField]
    private int howSlowHealthRegens;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Death();
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;
        if (regenHealth != null)
        {
            StopCoroutine(regenHealth);
        }
        regenHealth = StartCoroutine(RegenHealth());
    }
    public void HealDamage(float amount)
    {
        currentHealth += amount;
        healthBar.value = currentHealth;
    }

    public IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(timeBeforeRegenHealth);

        while(currentHealth < maxHealth)
        {
            currentHealth += maxHealth / howSlowHealthRegens;
            healthBar.value = currentHealth;
            yield return regenTick;
        }
        regenHealth = null;
    }

    void Death()
    {
        Destroy(gameObject);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);

        //SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }
}
