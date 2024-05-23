using UnityEngine;

public class IntermitentLight : MonoBehaviour
{
    public float switchInterval = 1.0f; // Intervalo de cambio en segundos
    public Color redColor = Color.red; // Color rojo
    public Color blueColor = Color.blue; // Color azul
    public GameObject objectToDeactivate; // GameObject a desactivar después de 10 segundos
    public float deactivationTime = 10.0f; // Tiempo para desactivar el GameObject en segundos

    private Light spotlight;
    private bool isRed = true;
    private float switchTimer = 0.0f;
    private float deactivationTimer = 0.0f;

    void Start()
    {
        // Obtener componente Light (Spotlight)
        spotlight = GetComponent<Light>();

        // Comenzar con el color rojo
        spotlight.color = redColor;

        // Iniciar temporizador de cambio de color
        switchTimer = switchInterval;

        // Iniciar temporizador de desactivación
        deactivationTimer = deactivationTime;
    }

    void Update()
    {
        // Actualizar temporizador de cambio de color
        switchTimer -= Time.deltaTime;
        if (switchTimer <= 0)
        {
            // Cambiar el color
            if (isRed)
            {
                spotlight.color = blueColor;
            }
            else
            {
                spotlight.color = redColor;
            }
            isRed = !isRed;
            switchTimer = switchInterval;
        }

        // Actualizar temporizador de desactivación
        if (objectToDeactivate.activeSelf)
        {
            deactivationTimer -= Time.deltaTime;
            if (deactivationTimer <= 0)
            {
                objectToDeactivate.SetActive(false);
            }
        }
    }
}
