using UnityEngine;
using UnityEngine.UI;

public class LiquidDetector : MonoBehaviour
{
    public Material mixingLiquidMaterial;
    private float initialFillValue;
    private float targetFillValue;
    private float duration = 0f; // Duración en segundos para el aumento gradual

    public float timer = 0f;
    public Slider slider; // Referencia al slider UI
    public GameObject check;
    public GameObject checkDetector;

    public bool Methanol = false;
    public bool Toluene = false;
    public bool Pottasium = false;
    public bool Ethyl = false;
    public bool Carbon = false;
    public bool Salicylic = false;


    void Start()
    {
      slider.gameObject.SetActive(false);
      check.SetActive(false);
      checkDetector.SetActive(false);
      initialFillValue = 0.499f;
      // Guardar el valor actual de "_Fill" como valor inicial
      mixingLiquidMaterial.SetFloat("_Fill", initialFillValue);
    }
    void Update()
    {
        if( Methanol && Toluene && Pottasium && Ethyl && Carbon && Salicylic == true)
        {
            checkDetector.SetActive(true);

        }
    }


    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger tiene una etiqueta específica
        if (other.CompareTag("Methanol"))
        {
            check.SetActive(false);
            duration = 10f;
            Debug.Log("Objeto Methanol detectado: " + other.gameObject.name);
            
            float startFillValue = mixingLiquidMaterial.GetFloat("_Fill");
            // Establecer el valor objetivo al que deseas que aumente gradualmente
            targetFillValue = startFillValue + 0.025f;
            if(Methanol == false){
            // Iniciar el ciclo para el aumento gradual
            StartCoroutine(GradualIncreaseFill());
            Methanol = true;
            }
        }
        else if (other.CompareTag("Toluene"))
        {
            check.SetActive(false);
            duration = 2f;
            Debug.Log("Objeto Toluene detectado: " + other.gameObject.name);

            float startFillValue = mixingLiquidMaterial.GetFloat("_Fill");

            // Incrementar Fill en 0.2
            targetFillValue = startFillValue + 0.010f;

            if(Toluene == false){
            // Iniciar el ciclo para el aumento gradual
            StartCoroutine(GradualIncreaseFill());
            Toluene = true;
            }
        }
         else if (other.CompareTag("Potassium"))
        {
            check.SetActive(false);
            duration = 2f;
            Debug.Log("Objeto Toluene detectado: " + other.gameObject.name);

            float startFillValue = mixingLiquidMaterial.GetFloat("_Fill");

            // Incrementar Fill en 0.2
            targetFillValue = startFillValue + 0.003f;

            if(Pottasium == false){
            // Iniciar el ciclo para el aumento gradual
            StartCoroutine(GradualIncreaseFill());
            Pottasium = true;
            }
        }
        else if (other.CompareTag("Ethyl"))
        {
            check.SetActive(false);
            duration = 2f;
            Debug.Log("Objeto Toluene detectado: " + other.gameObject.name);

            float startFillValue = mixingLiquidMaterial.GetFloat("_Fill");

            // Incrementar Fill en 0.2
            targetFillValue = startFillValue + 0.007f;

            if(Ethyl == false){
            // Iniciar el ciclo para el aumento gradual
            StartCoroutine(GradualIncreaseFill());
            Ethyl = true;
            }
        }
        else if (other.CompareTag("Carbon"))
        {
            check.SetActive(false);
            duration = 2f;
            Debug.Log("Objeto Toluene detectado: " + other.gameObject.name);

            float startFillValue = mixingLiquidMaterial.GetFloat("_Fill");

            // Incrementar Fill en 0.2
            targetFillValue = startFillValue + 0.007f;

            if(Carbon == false){
            // Iniciar el ciclo para el aumento gradual
            StartCoroutine(GradualIncreaseFill());
            Carbon = true;
            }
        }
        else if (other.CompareTag("Salicylic"))
        {
            check.SetActive(false);
            duration = 2f;
            Debug.Log("Objeto Toluene detectado: " + other.gameObject.name);

            float startFillValue = mixingLiquidMaterial.GetFloat("_Fill");

            // Incrementar Fill en 0.2
            targetFillValue = startFillValue + 0.007f;

            if(Salicylic == false){
            // Iniciar el ciclo para el aumento gradual
            StartCoroutine(GradualIncreaseFill());
            Salicylic = true;
            }
        }
    
    }

    System.Collections.IEnumerator GradualIncreaseFill()
    {
        slider.gameObject.SetActive(true);
        float startValue = 0f; // Valor inicial del slider
        float endValue = 1f; // Valor final del slide
        timer = 0f;

        // Obtener el valor inicial de _Fill
        float startFillValue = mixingLiquidMaterial.GetFloat("_Fill");

        // Realizar el aumento gradual dentro del lapso de tiempo especificado
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float fraction = timer / duration;
            float newFillValue = Mathf.Lerp(startFillValue, targetFillValue, fraction);
            slider.value = Mathf.Lerp(startValue, endValue, fraction); // Interpolación lineal entre los valores inicial y final
            mixingLiquidMaterial.SetFloat("_Fill", newFillValue);
            yield return null;
        }
        
        slider.value = endValue;
        slider.gameObject.SetActive(false);
        check.SetActive(true);

        // Asegurarse de que el valor final sea exactamente el valor objetivo
        mixingLiquidMaterial.SetFloat("_Fill", targetFillValue);
    }
}
