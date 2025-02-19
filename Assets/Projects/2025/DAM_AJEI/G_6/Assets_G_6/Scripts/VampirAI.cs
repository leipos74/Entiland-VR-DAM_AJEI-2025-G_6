using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis {
    public class VampirAI : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed = 1.0f;
        private  Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {
            Vector3 directrion = new Vector3(player.position.x - transform.position.x,0,player.position.z - transform.position.z).normalized;

            rb.MovePosition(rb.position + directrion * speed * Time.fixedDeltaTime);
        }
    }
}


