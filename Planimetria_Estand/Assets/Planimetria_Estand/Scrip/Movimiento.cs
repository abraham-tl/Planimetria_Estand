using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Vector3 posicion_inicial;
    float distance = 10;
    Inicializador iniciado;
    // Use this for initialization
    void Start()
    {
        posicion_inicial = transform.position;
        iniciado = FindObjectOfType<Inicializador>();
    }
  
    private void OnMouseDown()
    {
      
     
    }

    private void OnMouseUp()
    {
        iniciado.Ubicar_producto(this.gameObject);

    }

    void OnMouseDrag()
    {
        Vector3 posicionMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objetoPosicion = Camera.main.ScreenToWorldPoint(posicionMouse);

        transform.position = objetoPosicion;

    }
}
