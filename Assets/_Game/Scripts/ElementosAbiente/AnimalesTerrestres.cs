using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class AnimalesTerrestres : MonoBehaviour
{
    public PathCreator pathCreator;
    public float velocidad;
    public float recorrido;
    public Vector3[] puntos;
    //public Collider colaider;
    public LayerMask capas;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        //puntos = pathCreator.bezierPath.points.ToArray();
        //colaider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        recorrido += velocidad * Time.fixedDeltaTime;
        Vector3 posicion = pathCreator.path.GetPointAtDistance(recorrido);
        RaycastHit hit;
        Ray rayo = new Ray(posicion + Vector3.up , Vector3.down);
		if (Physics.Raycast(rayo, out hit, 4,capas))
		{
            posicion.y = hit.point.y;
		}
        transform.position = posicion - offset * Vector3.up ;
        transform.rotation = pathCreator.path.GetRotationAtDistance(recorrido);
        transform.forward = Vector3.Cross(Vector3.Cross(Vector3.up, transform.forward), Vector3.up);

    }

    private void OnDrawGizmosSelected()
    {
        transform.position = pathCreator.path.GetPointAtDistance(recorrido);
        transform.rotation = pathCreator.path.GetRotationAtDistance(recorrido);
    }
}
