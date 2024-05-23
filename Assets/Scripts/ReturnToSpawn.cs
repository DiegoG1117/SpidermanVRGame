using UnityEngine;

public class ReturnToSpawn : MonoBehaviour
{
    public Transform respawnPoint; // El punto al que el objeto debe regresar
    public float maxDistance = 2.0f; // La distancia máxima permitida antes de volver al punto de reaparición
    private Vector3 initialPosition; // La posición inicial del objeto
    
    void Start()
    {
        // Almacena la posición inicial del objeto
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calcula la distancia entre el objeto y el punto de reaparición
        float distanceToRespawnPoint = Vector3.Distance(transform.position, respawnPoint.position);

        // Si la distancia es mayor que la distancia máxima permitida, vuelve al punto de reaparición
        if (distanceToRespawnPoint > maxDistance)
        {
            transform.position = initialPosition; // Vuelve a la posición inicial
        }
    }
}
