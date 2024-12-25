using gameJam;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();
            health.TakeDamage(1);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    
    
}
