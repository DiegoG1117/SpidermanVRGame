using UnityEngine;

public class HandShooter : MonoBehaviour
{
    public bool HandCheck;
    public GameObject HandPoint;

    void Start()
    {
        HandCheck = false;
    }

    void Update()
    {
        if (HandCheck)
        {
            // Asignar la posición y la rotación del HandPoint al transform del GameObject
            transform.position = HandPoint.transform.position;
            transform.rotation = HandPoint.transform.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WebShooter"))
        {
            HandCheck = true;
        }
    }
}
