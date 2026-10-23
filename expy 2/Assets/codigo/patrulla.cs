using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 5f;

    private Vector2 posicionInicial;
    private int direccion = -1;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - posicionInicial.x) >= distancia)
        {
            direccion *= -1;
        }
    }
}