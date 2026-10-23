using UnityEngine;

public class moneda : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)

    {
        // Debug.Log("Colison trigger");
        Destroy(gameObject);
    }
}