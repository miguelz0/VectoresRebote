using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class libreriaVectores 
{
    public float x;
    public float y;
    

    public libreriaVectores(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public libreriaVectores suma(libreriaVectores v1, libreriaVectores v2)
    {
        
        x = v1.x + v2.x;
        y = v1.y + v2.y;
       var resultado = new libreriaVectores(x,y);
        return resultado;

    }
    public libreriaVectores resta(libreriaVectores v1, libreriaVectores v2)
    {
        x = v1.x - v2.x;
        y = v1.y - v2.y;
        var resultado = new libreriaVectores(x,y);
        return resultado;

    }
    public libreriaVectores multiplicacion(libreriaVectores v1, float z)
    {
        x = v1.x * z;
        y = v1.y * z;
        var resultado = new libreriaVectores(x,y);
        return resultado;
    }
    public float Encontrarmagnitud(libreriaVectores v1)
    {                

        return Mathf.Sqrt((v1.x * v1.x) + (v1.y * v1.y));
    }
    public libreriaVectores normalizar(libreriaVectores v1)
    {
        float valor = Encontrarmagnitud(v1);
        float normalx = v1.x / valor;
        float normaly = v1.y / valor;
        var resultado = new libreriaVectores(normalx, normaly);
        return resultado;
    }
    public override string ToString()
    {
        return ("("+x+","+y+")");
    }
    public void dibujar(libreriaVectores v1, Color color)
    {
        Vector3 temp = new Vector3(v1.x, v1.y, 0f);
        Debug.DrawLine(Vector3.zero, temp, color,0);

    }

    public void traslado(libreriaVectores v1, libreriaVectores v2)
    {
        Vector3 llegada = new Vector3(v1.x + v2.x, v1.y + v2.y);
        Vector3 origen = new Vector3(v1.x, v1.y);
        Debug.DrawLine(origen, llegada);


    }

    public void lerp(libreriaVectores v1, libreriaVectores v2, float rango = 0.5f)
    {
        libreriaVectores mitad = (suma(v1, v2));
        libreriaVectores diferencia = resta(v2, v1);
        mitad = multiplicacion(mitad, rango);
        diferencia = multiplicacion(diferencia, rango);
        diferencia.traslado(v1, diferencia);
        Vector3 mitadV3 = new Vector3(mitad.x, mitad.y, 0);
        Debug.DrawLine(Vector3.zero, mitadV3);

    }
    /*public libreriaVectores lerp(libreriaVectores v1, libreriaVectores v2, float rango)
    {

        libreriaVectores diferencia, mitad,slidder;
        diferencia = resta(v2, v1);
        diferencia.traslado(v1,diferencia);
        slidder = diferencia.multiplicacion(diferencia, rango);
        mitad = suma(v1, slidder);
        var resultado = new libreriaVectores(mitad.x,mitad.y);
        return resultado;
        


        
    }*/

}


