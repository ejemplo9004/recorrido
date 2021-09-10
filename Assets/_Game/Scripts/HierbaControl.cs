using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierbaControl : MonoBehaviour
{
	public LayerMask	capaHierba;
	public float		radio = 10;
	public float		offset;

	Collider[] cols;
	void Start()
    {
        
    }
	
    void FixedUpdate()
    {
		cols = Physics.OverlapSphere(transform.position + offset * transform.forward, radio,capaHierba);
		foreach (Collider collider in cols)
		{
			collider.transform.LookAt(transform);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position + offset * transform.forward, radio);
	}
}
