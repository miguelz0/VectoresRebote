
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
   
    public Vector2 desplazar;
    public Vector2 sumatoria;
    public float masa = 100;   
    public Vector2 velocidad, aceleracion, posicion, gravitacional;
    public Planeta planeta2;    
    Vector2 velmax = new Vector2(15, 15);
    void Start()
    {
        posicion = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Newton();
        AplicarFuerza();
        Walker();
        gravitacional.Draw(posicion,Color.green);
        
       

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
        transform.position = posicion;
    }
    public void AplicarFuerza()
    {
        sumatoria = gravitacional;
        aceleracion = (sumatoria / masa);
    }



    public void Newton()
    {
        Vector2 resultado = planeta2.posicion- posicion;
        float magnitud = resultado.magnitude;
        gravitacional = ((masa*planeta2.masa)/magnitud*magnitud)*resultado.normalized;
    }
    
    
}
