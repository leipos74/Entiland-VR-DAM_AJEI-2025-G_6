using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace EntilandVR.DosCinco.DAM_AJEI.G_Seis
{
    public class PlayerStats : MonoBehaviour
    {
        public TextMeshProUGUI puntuacionText;
        public Slider barraDeVida;

        private float puntuacionActual = 0;
        private float vidaActual;
        private float vidaMaxima = 100;

        private void Start()
        {
            vidaActual = vidaMaxima;
            if (barraDeVida != null)
            {
                barraDeVida.maxValue = vidaMaxima;
                barraDeVida.value = vidaActual;
            }
        }

        public void SumarPuntuacion(float puntuacion)
        {
            puntuacionActual += puntuacion;
            puntuacionText.text = "Puntuación: " + puntuacionActual.ToString();
        }

        public void RecibirDanio(float cantidadDanio)
        {
            vidaActual -= cantidadDanio;
            vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);
            ActualizarBarraDeVida();
        }

        public void ActualizarBarraDeVida()
        {
            if (barraDeVida != null)
            {
                barraDeVida.value = vidaActual;
            }
        }
    }
}