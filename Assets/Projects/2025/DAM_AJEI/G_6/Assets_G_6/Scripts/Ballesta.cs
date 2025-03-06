using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class Ballesta : MonoBehaviour
    {
        public Rigidbody body;

        public Transform barrelTip;
        public float hitPower = 1;
        public float recoilPower = 1;
        public float range = 100;
        public LayerMask layer;

        public AudioClip shootSound;
        public float shootVolume = 1f;
        [SerializeField] private flecha flecha;

        private void Start()
        {
            if (body == null && GetComponent<Rigidbody>() != null)
                body = GetComponent<Rigidbody>();
        }

        public void Shoot()
        {
            Debug.Log("Aaaaaaaaaaaaaaa");
            //Play the audio sound
            if (shootSound)
                AudioSource.PlayClipAtPoint(shootSound, transform.position, shootVolume);
                flecha.Disparar();
        }
    }
}
