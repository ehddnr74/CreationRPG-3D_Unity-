using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Collider col;
    TrailRenderer trailRenderer;
    void Start()
    {
        trailRenderer = GetComponentInChildren<TrailRenderer>();

        trailRenderer.enabled = false;
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("mSoulEater"))
        {
            other.GetComponent<SoulEater>().TakeDamege(17);
            Debug.Log("Attack");
        }
    }

    //private int CalculateDamage()
    //{
    //    if()
    //}

}
