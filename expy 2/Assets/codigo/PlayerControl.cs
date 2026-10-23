using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    public float horizontal;
    public float jumpForce;
    public bool enPiso;      //boleano para pernitir que el player salte o no

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //acceso al componente rigidbody2D
        enPiso = false;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");//lectura de tecla

        rb2d.AddForce(Vector2.right * speed * horizontal * Time.deltaTime);//procesa movimiento horizontal

        if (Input.GetKeyDown(KeyCode.Space) && enPiso) //condición tecla espacio y boleano verdadero
        {
            rb2d.AddForce(Vector2.up * jumpForce); //dandole fuerza al rigidbody
            enPiso = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("Colisionó!!");
        enPiso = true;
    }
}