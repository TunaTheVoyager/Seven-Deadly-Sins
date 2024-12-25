using DG.Tweening;
using UnityEngine;

public class food : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform _trn = collision.transform.root.GetComponent<Transform>();
            GameObject player = collision.gameObject;
            
            
            
            _trn.DOScale(_trn.localScale * 2 ,1);
            Destroy(gameObject);
        }
    }
}
