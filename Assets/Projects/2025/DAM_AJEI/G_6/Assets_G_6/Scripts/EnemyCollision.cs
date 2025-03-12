using EntilandVR.DosCinco.DAM_AJEI.G_Seis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class EnemyCollision : MonoBehaviour
    {
        public float danio = 10f;
        private bool puedeHacerDanio = true;
        public PlayerStats playerStats;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && puedeHacerDanio)
            {
                playerStats = GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    Debug.Log(other.tag);
                    playerStats.RecibirDanio(danio);
                    StartCoroutine(TemporizadorDanio());
                }
            }
        }

        private IEnumerator TemporizadorDanio()
        {
            puedeHacerDanio = false;
            yield return new WaitForSeconds(2);
            puedeHacerDanio = true;
        }
    }
}
