using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class AnimalesTerrestres : MonoBehaviour
{
    public PathCreator pathCreator;
    public float velocidad;
    public float recorrido;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        recorrido += velocidad * Time.fixedDeltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(recorrido);
        transform.rotation = pathCreator.path.GetRotationAtDistance(recorrido);
    }

    private void OnDrawGizmosSelected()
    {
        transform.position = pathCreator.path.GetPointAtDistance(recorrido);
        transform.rotation = pathCreator.path.GetRotationAtDistance(recorrido);
    }
}
