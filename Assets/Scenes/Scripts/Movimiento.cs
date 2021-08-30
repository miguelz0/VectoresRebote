
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Vector2 posicion;    
    public Vector2 desplazar;    
    public float maximoY=4.5f, minimoY=-4.5f, maximoX=4.5f, minimoX=-4.5f;
    public Vector2 velocidad, aceleracion;
    Vector2 velmax = new Vector2(49, 49);
    void Start()
    {              

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = posicion;
        posicion.Draw(Color.black);
        velocidad.Draw(posicion,Color.blue);
        aceleracion.Draw(posicion,Color.green);
        desplazar.Draw(posicion,Color.cyan);
        Walker();
        CheckRapidez();

        
    }   
    public void NuevaPosicion()
    {
        posicion = posicion + desplazar;
        if (posicion.x<minimoX && posicion.x<maximoX)
        {
            desplazar.x = -desplazar.x;
        }
        if (posicion.x>maximoX &&posicion.x>minimoX)
        {
            desplazar.x = -desplazar.x;           
        }
        if(posicion.y<minimoY && posicion.y < maximoY)
        {
            desplazar.y = -desplazar.y;
        }
        if(posicion.y>maximoY && posicion.y > minimoY)
        {
            desplazar.y = -desplazar.y;
        }        
        
    }
    public void Walker()
    {
        posicion = posicion + velocidad * Time.deltaTime;
        

        
        if (velocidad.x < velmax.x && velocidad.y < velmax.y)
        {
            velocidad = velocidad + aceleracion * Time.deltaTime;
        }
        else
        {
            velocidad = velmax;
        }
        
        if (posicion.x < minimoX || posicion.x > maximoX)
        {
            velocidad.x= - velocidad.x;
            //aceleracion.x = -aceleracion.x;
            if (posicion.x > maximoX)
            {
                posicion.x = 4.5f;
            }
            if (posicion.x < minimoX)
            {
                posicion.x = -4.5f;
            }
        }        
        if (posicion.y < minimoY || posicion.y > maximoY)
        {
            velocidad.y = -velocidad.y;
            //aceleracion.y = -aceleracion.y;
            if (posicion.y > maximoY)
            {
                posicion.y = 4.5f;
            }
            if (posicion.y < minimoY)
            {
                posicion.y = -4.5f;
            }

        }        


    }
    public void CheckRapidez()
    {
        if (velocidad.magnitude > velmax.magnitude)
        {
            Vector3.Normalize(velocidad);
            velocidad*= velmax;
        }
    }
        

    
}
