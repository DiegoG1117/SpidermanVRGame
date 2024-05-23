using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebFluid : MonoBehaviour
{
    public Material mixingLiquidMaterial;
    private float initialFillValue;
    private float targetFillValue;
    private float duration = 0f; // Duración en segundos para el aumento gradual
    public float timer = 0f;
    public Slider slider; // Referencia al slider UI
    public GameObject particleSystem;
    public bool Stick = false;


    void Update()
    {
        // Obtener la dirección local del eje Y del objeto
        Vector3 localUp = transform.up;

        // Comparar la dirección local del eje Y con el vector de arriba del mundo (0, 1, 0)
        if (Vector3.Dot(localUp, Vector3.up) > 0.9f)
        {
            //Debug.Log("La cara de arriba está orientada hacia arriba.");
            particleSystem.SetActive(true); // Activar el objeto

                timer += Time.deltaTime;
            if (timer >= 0.05f)
            {
                float currentFill = mixingLiquidMaterial.GetFloat("_Fill");
                float newFillValue = currentFill - 0.0009f;
                mixingLiquidMaterial.SetFloat("_Fill", Mathf.Max(newFillValue, 0f)); // Asegurar que el valor no sea negativo
                timer = 0f; // Reiniciar el temporizador
            }
        }
        else
        {
            //Debug.Log("La cara de arriba no está orientada hacia arriba.");
            particleSystem.SetActive(false); // Desactivar el objeto
        }
    }
    void Start()
    {

        particleSystem.SetActive(false); // Activar el objeto

    }


    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger tiene una etiqueta específica
        if (other.CompareTag("MixingStick"))
        {
            if(Stick == false){
            duration = 20f;
            StartCoroutine(GradualIncreaseFill());
            Stick = true;
            }

        }
    }
     System.Collections.IEnumerator GradualIncreaseFill()
    {
        slider.gameObject.SetActive(true);
        float startValue = 0f; // Valor inicial del slider
        float endValue = 1f; // Valor final del slide
        timer = 0f;

        // Realizar el aumento gradual dentro del lapso de tiempo especificado
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float fraction = timer / duration;
            slider.value = Mathf.Lerp(startValue, endValue, fraction); // Interpolación lineal entre los valores inicial y final
            yield return null;
        }
        
        slider.value = endValue;
        slider.gameObject.SetActive(false);
    }
}
