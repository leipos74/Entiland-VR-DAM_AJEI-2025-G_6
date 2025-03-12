using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class CinturonFollower : MonoBehaviour
    {
        void Update()
        {
            Vector3 currentRotation = transform.eulerAngles;
            transform.eulerAngles = new Vector3(0, currentRotation.y, 0);
        }

    }
}