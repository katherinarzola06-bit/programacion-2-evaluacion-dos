using UnityEngine;
using UnityEngine.SceneManagement; //Librería para usar cambios de escenas

public class CambioDeEscena : MonoBehaviour
{
    public string NombreDelNivel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();    //Se ejecuta el cierre de la aplicación
            Debug.Log("Se cerró mi juego");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(NombreDelNivel);
        }
    }
}