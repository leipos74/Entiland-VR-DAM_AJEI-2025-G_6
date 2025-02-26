using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
using EntilandVR.DosCinco.DAM_AJEI.G_Seis;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class Cinturon : MonoBehaviour
    {
        public Transform snapPoint; // Punto donde se ajustará la granada
        private HolyGranade currentGranade; // Referencia a la granada almacenada

        private void OnTriggerEnter(Collider other)
        {
            HolyGranade granade = other.GetComponent<HolyGranade>();
            if (granade != null && currentGranade == null) // Si es una granada y no hay otra almacenada
            {
                StoreGranade(granade);
            }
        }

        private void StoreGranade(HolyGranade granade)
        {
            currentGranade = granade;
            Grabbable grabbable = granade.GetComponent<Grabbable>();
            Rigidbody rb = granade.GetComponent<Rigidbody>();

            // Deshabilitar la gravedad y hacer que la granada siga al cinturón
            rb.useGravity = false;
            rb.isKinematic = true;
            granade.transform.SetParent(snapPoint);

            // Ajustar la posición y rotación de la granada
            granade.transform.localPosition = Vector3.zero;
            granade.transform.localRotation = Quaternion.identity;

            // Habilitar la detección para poder agarrarla de nuevo
            grabbable.enabled = true;
            grabbable.gameObject.layer = LayerMask.NameToLayer("Default"); // Asegurar que la capa es detectable
            grabbable.OnGrabEvent += OnGranadeGrab;
        }

        private void OnGranadeGrab(Hand hand, Grabbable grab)
        {
            if (currentGranade != null)
            {
                Rigidbody rb = currentGranade.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;

                // Quitar la granada del cinturón
                currentGranade.transform.SetParent(null);
                currentGranade.GetComponent<Grabbable>().OnGrabEvent -= OnGranadeGrab;
                currentGranade = null;
            }
        }
    }
}