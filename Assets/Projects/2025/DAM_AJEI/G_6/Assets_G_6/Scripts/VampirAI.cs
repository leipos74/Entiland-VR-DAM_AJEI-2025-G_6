using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis {
    public class VampirAI : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed = 1.0f;
        private  Rigidbody rb;
        public float health = 100f;
       [SerializeField] private AudioSource audioSource;
        public PlayerStats puntuacionScript;
        public float points = 100;


        private void Start()
        {
            player = GameObject.Find("Auto Hand Player").GetComponent<Transform>();
            puntuacionScript = GameObject.Find("Unity UI Canvas").GetComponent<PlayerStats>();
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (health <= 0)
            {
                puntuacionScript.SumarPuntuacion(points);
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            Vector3 directrion = new Vector3(player.position.x - transform.position.x,0,player.position.z - transform.position.z).normalized;

            rb.MovePosition(rb.position + directrion * speed * Time.fixedDeltaTime);
        }


        public void DamageAI(float damage)
        {
            health -= damage;
        }
    }

   
}


