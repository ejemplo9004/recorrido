using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EfectoColores : MonoBehaviour
{
    Image image;
    public Gradient gradiente;

    void Start()
    {
        image = GetComponent<Image>();
    }
    
    void FixedUpdate()
    {
        image.color = gradiente.Evaluate((Mathf.Sin(Time.time) + 1) / 2f);
    }
}
