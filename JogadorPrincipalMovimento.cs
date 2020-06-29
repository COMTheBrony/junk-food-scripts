using CriarPersonagem.Jogador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CriarPersonagem.Jogador
{
    public class JogadorPrincipalMovimento : JogadorControleRB
    {
        protected override void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ResetImpactY();
                //AddForce(Vector3.up, jumpForce);
                if (cc.isGrounded)
                {
                    ResetImpactY();
                    AddForce(Vector3.up, jumpForce);
                }
            }
        }
    }
}
