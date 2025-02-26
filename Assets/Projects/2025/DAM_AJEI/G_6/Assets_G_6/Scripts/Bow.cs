using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntilandVR.DosCinco.DAM_AJEI.G_6
{
    [RequireComponent(typeof(LineRenderer))]

    public class Bow : MonoBehaviour
    {
        [SerializeField]
        private Transform endpoint_1, endpoint_2;

        private LineRenderer lineRenderer;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        public void CreateString(Vector3? midPosition)
        {
            Vector3[] linePoints = new Vector3[midPosition == null ? 2 : 3];
            linePoints[0] = endpoint_1.localPosition;
            if (midPosition != null)
            {
                linePoints[1] = transform.InverseTransformPoint(midPosition.Value);
            }
            linePoints[^1] = endpoint_2.localPosition;

            lineRenderer.positionCount = linePoints.Length;
            lineRenderer.SetPositions(linePoints);
        }

        private void Start()
        {
            CreateString(null);
        }
    }
}


