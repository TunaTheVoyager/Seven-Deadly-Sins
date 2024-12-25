using System;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health can = other.gameObject.GetComponent<Health>();
            can.TakeDamage(1);
        }
    }
}
