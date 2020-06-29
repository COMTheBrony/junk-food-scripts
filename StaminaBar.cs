using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 100;
    private int currentStamina;
    public bool notEnoughStamina = false;

    private Coroutine regen;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    void Start()
    {
        staminaBar.gameObject.SetActive(false);
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            notEnoughStamina = false;
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)            
                StopCoroutine(regen);
            
            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            //aqui dá pra colocar um texto dizendo o mesmo, é só usar SetActive
            //Debug.Log("Stamina insuficiente.");
            notEnoughStamina = true;
        }
    }

    private void Update()
    {
        //if (staminaBar.value == maxStamina)
        //    staminaBar.gameObject.SetActive(false);
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;

            yield return regenTick;
        }
        regen = null;
        staminaBar.gameObject.SetActive(false);
    }

}
