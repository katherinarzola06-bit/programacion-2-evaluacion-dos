using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour

{

    public Transform player;

    public float Velocidad = 5f;

    public Vector3 offset;

    void LateUpdate()

    {

        Vector3 targetPosition = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Velocidad * Time.deltaTime);

    }
}