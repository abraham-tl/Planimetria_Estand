using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializador : MonoBehaviour {
    public bool verificar;
    public Vector3[,] ubicaciones;
    public string[,] orden_productos;
    public GameObject[,] estand;
    // Use this for initialization

    public int columnas;
    public int filas;
    public float pos_inicial_h;
    public float pos_inicial_v;
    public int Cantidad_productos;
    float Tiempo;
    int intentos;
	void Start ()
    {
        verificar = false;
        columnas = 9;
        filas = 2;
        pos_inicial_h = -6f;
        pos_inicial_v = 3;
        ubicaciones = new Vector3[columnas,filas];
        orden_productos = new string[columnas,filas];    
        CragarUbicaciones();
        estand = new GameObject[columnas,filas];
        Crear_orden();
        Tiempo = 0;
        intentos = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Submit"))
        {
            intentos += 1;
            print("HOLA");
        }
		if(verificar)
        {
            verificar = false;
            Verificar_planimtria();
        }
        Tiempo += Time.deltaTime;
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
                pos_h += 0.55f;
        
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
            estand[pos_j, pos_i] = ob;
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
        orden_productos[1,0] = "Acondicionador_tradicional";
        orden_productos[2,0] = "Locion_capilar";
        orden_productos[3,0] = "Serum_capilar";
        orden_productos[4,0] = "2en1";
        orden_productos[5,0] = "Control_caspa";
        orden_productos[6,0] = "Shampoo_hombre";
        orden_productos[7,0] = "Gel";
        //orden_productos[1,0] = ""
        //orden_productos[1,1] = ""
        //orden_productos[1,2] = ""

    }

    public void Verificar_planimtria()
    {
        intentos += 1;
        bool diferencia = false;
        for(int i =0;i<1;i++)
        {
            for(int j=0;j<columnas;j++)
            {
                if (estand[j,i] != null && orden_productos[j, i] != estand[j, i].name)
                {

                    diferencia = true;
                }
            }
        }
        if(diferencia)
        {

        }
        else
        {
            print(Tiempo);
        }


    }  

}
