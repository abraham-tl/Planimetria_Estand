﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
   public bool acomodado = true;
    public bool movimiento = false;
    float distance = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            acomodado = false;
            movimiento = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
           
            movimiento = false;
        }

        if((!acomodado) && (!movimiento))
        {

        }


    }

    void OnMouseDrag()
    {
        Vector3 posicionMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objetoPosicion = Camera.main.ScreenToWorldPoint(posicionMouse);

        transform.position = objetoPosicion;
        print(transform.name);
       
    }

}