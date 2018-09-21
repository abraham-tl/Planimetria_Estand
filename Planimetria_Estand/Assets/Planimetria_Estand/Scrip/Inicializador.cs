using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializador : MonoBehaviour {
    public Vector3[,] ubicaciones;
    public string[,] orden_productos;
    // Use this for initialization

    public int columnas;
    public int filas;
    public float pos_inicial_h;
    public float pos_inicial_v;
    public int Cantidad_productos;     
	void Start ()
    {
       
        columnas = 9;
        filas = 2;
        pos_inicial_h = -8.3f;
        pos_inicial_v = 3;
        ubicaciones = new Vector3[columnas,filas];
        orden_productos = new string[columnas,filas];    
        CragarUbicaciones();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void CragarUbicaciones()
    {
        float pos_h;
        float pos_v = pos_inicial_v;
        for (int i =0; i<filas;i++)
        {
            pos_h = pos_inicial_h;
            for (int j=0;j<columnas;j++)
            {
                ubicaciones[j,i] = new Vector3(pos_h, pos_v, 0);
                pos_h += 0.6f;
                print(ubicaciones[j, i]);
            }
            pos_v -= 2;
         
        }
    }

    public void Ubicar_producto(GameObject ob)
    {
        int pos_i = 0;
        int pos_j = 0;
        bool cerca = false;
        for (int i=0;i<filas;i++)
        {
            for(int j=0;j<columnas;j++)
            {
                float a = (ob.transform.position - ubicaciones[j,i]).magnitude;

                if (a <= 0.5f && a <= (ob.transform.position - ubicaciones[pos_j, pos_i]).magnitude)
                {
                    pos_i = i;
                    pos_j = j;
                    cerca = true;
                }
            }            
        }
        if (cerca)
        {
            ob.gameObject.transform.position = ubicaciones[pos_j,pos_i];
        }
        else
        {
            ob.transform.position = ob.gameObject.GetComponent<Movimiento>().posicion_inicial;
        }
    }
    public void Mostrar_ubicaciones()
    {
        for (int i = 0; i < filas; i++)
        {
            for(int j =0;j<columnas;j++)
            {
                print(ubicaciones[j,i]);
            }            
        }
    }

    void Crear_orden()
    {
        orden_productos[0,0] = "Shampoo_tradicional";
        orden_productos[0,1] = "Acondicionador_tradicional";
        orden_productos[0,2] = ""
             //orden_productos[0,3] = ""
             //orden_productos[0,4] = ""
             //orden_productos[0,5] = ""
             //orden_productos[0,6] = ""
             //orden_productos[0,7] = ""
             //orden_productos[1,0] = ""
             //orden_productos[1,1] = ""
             //orden_productos[1,2] = ""

    }

    void Verificar_planimtria()
    {
        for(int i =0;i<filas;i++)
        {
            for(int j=0;j<columnas;j++)
            {
               
            }
        }
    }
}
