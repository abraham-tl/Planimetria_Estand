using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializador : MonoBehaviour {
    public Vector3[] ubicaciones;
	// Use this for initialization
	void Start () {

        ubicaciones = new Vector3[3];
             
        CragarUbicaciones();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void CragarUbicaciones()
    {
        
        ubicaciones[0] = new Vector3(-8.3f, 3, 0);
        ubicaciones[1] = new Vector3(-7.7f, 3, 0);
        ubicaciones[2] = new Vector3(-7.1f, 3, 0);

    }

    public void Ubicar_producto(GameObject ob)
    {
        int pos = 0;
        bool cerca = false;
        for (int i=0;i<3;i++)
        {
            float a = (ob.transform.position - ubicaciones[i]).magnitude;
           
            if (a <= 0.5f && a <= (ob.transform.position - ubicaciones[pos]).magnitude )
            {
                pos = i;
                cerca = true;
            }
        }
        if (cerca)
        {
            ob.gameObject.transform.position = ubicaciones[pos];
        }
        else
        {
            ob.transform.position = ob.gameObject.GetComponent<Movimiento>().posicion_inicial;
        }
    }
    public void Mostrar_ubicaciones()
    {
        for (int i = 0; i < 2; i++)
        {
            print(ubicaciones[i]);
        }
    }
}
