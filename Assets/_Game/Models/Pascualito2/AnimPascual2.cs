using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPascual2 : MonoBehaviour
{
    public Animator animator;
    public LayerMask capas;
    public GameObject pivote;
    public bool piso;
    public Transform padre;

    Vector3 offset;
    RaycastHit hit;
    Ray rayo;
    int cuenta;
    public int cuantaCuenta = 3;
	private void Start()
	{
        padre = transform.parent;
        transform.parent = null;
        offset = transform.position - padre.position;
	}
	void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, padre.position + offset, Time.deltaTime * 2);
        transform.position = padre.position + offset;
        animator.SetFloat("velocidad", Mathf.Abs(Input.GetAxis("Vertical")));
		if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
		{
            transform.forward = padre.forward;
		}
        rayo = new Ray(pivote.transform.position + Vector3.one*0.01f, Vector3.down);
        hit = new RaycastHit();
        piso = Physics.Raycast(rayo, out hit, 1f);
		if (!piso)
		{
            cuenta++;
		}
		else
		{
            cuenta = 0;
		}
		if (piso)
		{
            animator.SetBool("piso", true);
		}
		else
		{
			if (cuenta > cuantaCuenta)
            {
                animator.SetBool("piso", false);
			}
			else
			{
                animator.SetBool("piso", true);
            }
		}
    }
}
