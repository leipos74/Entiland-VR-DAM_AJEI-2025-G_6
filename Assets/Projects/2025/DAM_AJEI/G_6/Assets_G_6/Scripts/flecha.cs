using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis { 

public class flecha : MonoBehaviour
{
        private bool isShoot = false;
        private Rigidbody body;
        private void Start()
        {
            body = GetComponent<Rigidbody>();
            transform.localPosition = new Vector3(1.817f, 0, -0.619f);
            transform.localScale = new Vector3(6, 0.4f, 0.4f);
            transform.localRotation = Quaternion.identity;

        }

        private void Update()
        {
            if (isShoot)
            {
                body.isKinematic = false;
                body.AddForce(transform.right * 20, ForceMode.VelocityChange);
                isShoot = false; // Detenemos el disparo para no repetirlo
            }
        }

        public void Disparar()
        {
            isShoot = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Obstacle"){
                VampirAI aiTemp = other.gameObject.GetComponent<VampirAI>();
                aiTemp.DamageAI(100);
            }
        }
    }

}