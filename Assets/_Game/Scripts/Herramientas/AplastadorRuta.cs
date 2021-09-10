using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
[RequireComponent(typeof(PathCreator))]
public class AplastadorRuta : MonoBehaviour
{
    public PathCreator mipath;
    public Vector3[] puntos;

    private void OnDrawGizmosSelected()
    {
        if (mipath == null)
        {
            mipath = GetComponent<PathCreator>();
        }
        
    }
    
    [ContextMenu("Aplanar")]
    public void Aplastar()
    {
        puntos = mipath.EditorData.bezierPath.points.ToArray();
        Ray ray;
        RaycastHit hit;
        Vector3 origen;
        for (int i = 0; i < puntos.Length; i++)
        {
            origen = puntos[i] + transform.position;
            origen.y = 40;
            ray = new Ray(origen, Vector3.down);
            if (Physics.Raycast(ray,out hit))
            {
                puntos[i].y = hit.point.y - transform.position.y;
                mipath.bezierPath.points[i] = puntos[i];
            }
            
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
