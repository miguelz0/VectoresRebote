using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Movimiento))]

public class MovimientoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        bool botonclick= GUILayout.Button("Actualizar");
        if (botonclick)
        {
            
             Movimiento Movimiento = target as Movimiento;
             Movimiento.Walker();
            
        }
    }
    
}
