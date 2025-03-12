using EntilandVR.DosCinco.DAM_AJEI.G_Seis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class PlayerCollision : MonoBehaviour
    {
        public PlayerStats playerStats;
        private bool puedeRecibirDanio = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!puedeRecibirDanio) return;

            if (other.CompareTag("Obstacle"))
            {
                EnemyCollision enemy = other.GetComponent<EnemyCollision>();
                if (enemy != null)
                {
                    playerStats.RecibirDanio(enemy.danio);
                    playerStats.ActualizarBarraDeVida();
                    StartCoroutine(TemporizadorDanio());
                }
            }
        }

        private IEnumerator TemporizadorDanio()
        {
            puedeRecibirDanio = false;
            yield return new WaitForSeconds(2);
            puedeRecibirDanio = true;
        }
    }
}
