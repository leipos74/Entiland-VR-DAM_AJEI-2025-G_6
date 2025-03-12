using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemigoComun;
        public GameObject enemigoRaro;
        public Transform[] puntosDeSpawn;
        public float tiempoEntreSpawns = 3f;
        public float probabilidadEnemigoRaro = 0.2f; // 20% de probabilidad

        private void Start()
        {
            StartCoroutine(SpawnEnemigos());
        }

        private IEnumerator SpawnEnemigos()
        {
            while (true)
            {
                yield return new WaitForSeconds(tiempoEntreSpawns);
                SpawnEnemigo();
            }
        }

        private void SpawnEnemigo()
        {
            Transform spawnPoint = puntosDeSpawn[Random.Range(0, puntosDeSpawn.Length)];
            GameObject enemigo = Random.value < probabilidadEnemigoRaro ? enemigoRaro : enemigoComun;
            Instantiate(enemigo, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
