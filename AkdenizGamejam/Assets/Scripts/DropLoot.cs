using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameJam
{
    public class DropLoot : MonoBehaviour
    {
    
        [SerializeField] GameObject _dropItemPrefab;

    
    
        public virtual void OnDeath()
        {
            Instantiate(_dropItemPrefab, transform.position, transform.rotation);
        }
    }
}
