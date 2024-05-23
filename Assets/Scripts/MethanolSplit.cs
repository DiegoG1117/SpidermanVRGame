using UnityEngine;

public class MethanolSplit : MonoBehaviour
{
    public GameObject particleSystem;
     void Start()
    {
        particleSystem.SetActive(false); // Activar el objeto
    }
    void Update()
    {
        // Obtener la dirección local del eje Y del objeto
        Vector3 localUp = transform.up;

        // Comparar la dirección local del eje Y con el vector de arriba del mundo (0, 1, 0)
        if (Vector3.Dot(localUp, Vector3.up) > 0.9f)
        {
            //Debug.Log("La cara de arriba está orientada hacia arriba.");
            particleSystem.SetActive(false); // Activar el objeto
        }
        else
        {
            //Debug.Log("La cara de arriba no está orientada hacia arriba.");
            particleSystem.SetActive(true); // Desactivar el objeto
        }
    }
}
