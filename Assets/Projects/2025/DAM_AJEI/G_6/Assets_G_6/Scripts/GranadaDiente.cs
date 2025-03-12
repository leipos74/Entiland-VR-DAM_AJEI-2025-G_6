using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class GranadaDiente : MonoBehaviour
    {
        private BoxCollider coll;

        private void Start()
        {
            coll = GetComponent<BoxCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                HolyGranade granada = other.GetComponent<HolyGranade>();
                if (granada != null && granada.pinJoint != null)
                {
                    // Rompe el joint forzando la ruptura asignándole un breakForce de 0.
                    granada.pinJoint.breakForce = 0f;

                    // Alternativamente, podrías destruir el componente para romperlo inmediatamente:
                    // Destroy(granada.pinJoint);
                }
            }
        }
    }
}
