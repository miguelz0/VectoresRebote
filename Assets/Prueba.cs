using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    // Start is called before the first frame update
    public libreriaVectores prueba1;
    public libreriaVectores prueba2;
    public libreriaVectores traslado;
    public libreriaVectores diferencia;
    public libreriaVectores mitad;
    public libreriaVectores lerpPrueba;
    public float x=0.5f;
    
    void Start()
    {
        prueba1 = new libreriaVectores(20, 5);
        prueba2 = new libreriaVectores(3, 3);

        //traslado = new libreriaVectores(0, 0);
        

    }


    // Update is called once per frame
    void Update()
    {

        diferencia = diferencia.resta(prueba2, prueba1);
        diferencia.traslado(prueba1, diferencia);
        lerpPrueba.lerp(prueba1, prueba2, x);
        //lerpPrueba.lerp(prueba1, prueba2, x);

        //mitad = (mitad.suma(prueba1, diferencia.multiplicacion(diferencia,x)));

        //prueba1.traslado(prueba1, traslado);
        prueba2.dibujar(prueba2, Color.green);
        prueba1.dibujar(prueba1, Color.yellow);
        diferencia.dibujar(diferencia, Color.black);
        
        //lerpPrueba.dibujar(lerpPrueba, Color.blue);
        
        //diferencia.traslado(diferencia, prueba1, Color.grey);
        //mitad.dibujar(mitad, Color.yellow);
        
       
    }
}
