using UnityEngine;
using UnityEngine.SceneManagement;

public class kill : MonoBehaviour

{

    public string nombreEscena;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        SceneManager.LoadScene(nombreEscena);
    }
}

