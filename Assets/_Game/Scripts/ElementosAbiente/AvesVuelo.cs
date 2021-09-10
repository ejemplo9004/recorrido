using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

[RequireComponent(typeof(Animator))]
public class AvesVuelo : MonoBehaviour
{
    Animator animator;
    public Vector2 randomAleteo;
    public float velocidad;
    public Vector3 centro;
    public float radio;
    public float velRotacion;
    Transform pivote;
    const float TAU = 6.2832f;

    void Start()
    {
        Invoke("Aletear", Random.Range(randomAleteo.x, randomAleteo.y));
        animator = GetComponent<Animator>();
        pivote = (new GameObject()).transform;
        InvokeRepeating("CambiarPosicion", 0, 80);
        StartCoroutine(ReMirar());
    }

    void Aletear()
    {
        animator.SetTrigger("aletear");
        Invoke("Aletear", Random.Range(randomAleteo.x, randomAleteo.y));
    }
    
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * velocidad * Time.fixedDeltaTime);
        transform.rotation=(Quaternion.Lerp(transform.rotation, pivote.rotation, velRotacion * Time.fixedDeltaTime));
        if ((transform.position - pivote.position).sqrMagnitude < 8)
        {
            CambiarPosicion();
        }
    }

    [ContextMenu("Centrar en posición")]
    void CentrarEnPosicionActual()
    {
        centro = transform.position;
    }

    void CambiarPosicion()
    {
        Vector3 lugar = new Vector3(
            Mathf.Sin(Random.Range(0f,1f)*TAU),
            0,
            Mathf.Cos(Random.Range(0f,1f)*TAU)
            );
        pivote.transform.position = centro + lugar * Random.Range(0, radio);
        pivote.forward = (pivote.position - transform.position).normalized;
    }

    IEnumerator ReMirar()
    {
        yield return new WaitForSeconds(2);
        pivote.forward = (pivote.position - transform.position).normalized;
        StartCoroutine(ReMirar());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(centro, 0.5f);
#if (UNITY_EDITOR)
        Handles.color = Color.green;
        Handles.DrawWireDisc(centro, Vector3.up, radio);
#endif
        Gizmos.color = Color.red;
        if(pivote != null)
            Gizmos.DrawSphere(pivote.position, 0.5f);

    }
}
