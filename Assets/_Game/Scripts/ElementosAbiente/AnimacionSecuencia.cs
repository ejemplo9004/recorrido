using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class AnimacionSecuencia : MonoBehaviour
{
    public Sprite[] imagenes;
    public float tiempo;

    int i;
    SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        StartCoroutine(Animar());
    }
    
    IEnumerator Animar()
    {
        i = (i + 1) % imagenes.Length;
        spr.sprite = imagenes[i];
        yield return new WaitForSeconds(tiempo);
        StartCoroutine(Animar());
    }
}
