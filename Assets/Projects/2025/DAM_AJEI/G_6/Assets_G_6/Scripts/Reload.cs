using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class Reload : MonoBehaviour
    {
        [SerializeField] private Ballesta ballesta;

        public GameObject prefab;
        public Transform parentTransform;
        public Transform Ballestaposition;

        public Transform CAMERA;

        private BoxCollider coll;
        private void Start()
        {
            coll = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            transform.rotation = CAMERA.transform.rotation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!ballesta.isFlecha)
            {
                GameObject newObject = Instantiate(prefab);
                newObject.transform.SetParent(parentTransform);

                ballesta.flecha = newObject.GetComponent<flecha>();

                ballesta.isFlecha = true;
            }
            
        }
    }
}
