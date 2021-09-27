
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField]private Vector2 posicion;    
    public Vector2 desplazar;
    public Vector2 fuerza, sumatoria, friccion, resistencia, gravitatoria;
    public float masa=1;
    public float maximoY=4.5f, minimoY=-4.5f, maximoX=4.5f, minimoX=-4.5f;
    public Vector2 velocidad, aceleracion,peso;
    public Transform objetivo;
    public float rebote, coeficiente=0.5f, coeficiente2, masa2;
    public bool bordes=true; 
    Vector2 velmax = new Vector2(15, 15);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetearAceleracion();
        CheckRapidez();
        transform.position = posicion;
        posicion.Draw(Color.black);
        velocidad.Draw(posicion,Color.blue);
        aceleracion.Draw(posicion,Color.green);
        desplazar.Draw(posicion,Color.cyan);
        Gravedad();
        Friccion();
        //Resistencia();
        AplicarFuerza();        
        Walker();      
        //Rastreo();       

        
    }
    public void ResetearAceleracion()
    {
        aceleracion.x = 0;
        aceleracion.y = 0;
    }
    public void NuevaPosicion()
    {
        if (bordes == true)
        {
            posicion = posicion + desplazar;
            if (posicion.x < minimoX && posicion.x < maximoX)
            {
                desplazar.x = -desplazar.x;
            }
            if (posicion.x > maximoX && posicion.x > minimoX)
            {
                desplazar.x = -desplazar.x;
            }
            if (posicion.y < minimoY && posicion.y < maximoY)
            {
                desplazar.y = -desplazar.y;
            }
            if (posicion.y > maximoY && posicion.y > minimoY)
            {
                desplazar.y = -desplazar.y;
            }

        }

    }
    public void Walker()
    {        
        velocidad = velocidad + aceleracion * Time.deltaTime;
        posicion = posicion + velocidad * Time.deltaTime;       
               
        if (velocidad.x < velmax.x && velocidad.y < velmax.y)
        {
            velocidad = velocidad + aceleracion * Time.deltaTime;
        }
        else
        {
            velocidad = velmax;
        }
        if (bordes == true)
        {
            if (posicion.x < minimoX || posicion.x > maximoX)
            {
                velocidad.x = -velocidad.x * rebote;

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
                velocidad.y = -velocidad.y * rebote;

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


    }
    public void Gravedad()
    {
        Vector2 gravedad = new Vector2(0, -9.8f);        
        peso = masa *gravedad;

    }
    public void Friccion()
    {        
        friccion = -coeficiente*velocidad.normalized;
    }
    public void AplicarFuerza()
    {        
        sumatoria = fuerza + peso + friccion+ resistencia;       
        aceleracion = (sumatoria / masa);
    }
    
    
    public void CheckRapidez()
    {
        if (velocidad.magnitude > velmax.magnitude)
        {
            Vector3.Normalize(velocidad);
            velocidad*= velmax;
        }
    }
    
        
    public void Rastreo()
    {
        aceleracion.x = objetivo.position.x- posicion.x;
        aceleracion.y = objetivo.position.y- posicion.y;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Resistencia();
    }
    public void  Resistencia()
    {        
            float velocidadMag = velocidad.magnitude;
            resistencia = -0.5f * velocidadMag * velocidadMag * coeficiente2 * velocidad.normalized; 
    }    
    
    
}
