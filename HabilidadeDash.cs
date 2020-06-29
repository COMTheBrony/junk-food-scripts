using CriarPersonagem.Jogador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CriarPersonagem.Habilidades
{
    [RequireComponent(typeof(JogadorPrincipalMovimento))]
    public class HabilidadeDash : Habilidade
    {
        [SerializeField] private float dashForce;
        [SerializeField] private float dashDuration;

        [SerializeField] private int staminaCost;

        private JogadorPrincipalMovimento jogadorPrincipalMovimento;

        private JogadorStats jogadorStats;
        public StaminaBar staminaBar;

        private void Awake()
        {
            jogadorPrincipalMovimento = GetComponent<JogadorPrincipalMovimento>();
            jogadorStats = GetComponent<JogadorStats>();
        }

        private void Update()
        {
            if (jogadorStats.playerLevel >= 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    staminaBar.gameObject.SetActive(true);
                    staminaBar.UseStamina(staminaCost);
                    if (staminaBar.notEnoughStamina != true)
                    {
                        StartCoroutine(Cast());
                    }
                }                    
            }
        }

        public override IEnumerator Cast()
        {
            jogadorPrincipalMovimento.AddForce(Camera.main.transform.forward, dashForce);
            

            yield return new WaitForSeconds(dashDuration);

            jogadorPrincipalMovimento.ResetImpact();
        }
    }
}