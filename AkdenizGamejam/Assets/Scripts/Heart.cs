using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Heart : MonoBehaviour
    {
        private int _healAmound = 1;
        public virtual void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Health playerHealth = collision.transform.root.GetComponent<Health>();

                playerHealth.Heal(_healAmound);
                Destroy(gameObject);
            }
        }

        public void saniyeEkle()
        {
            GameObject player = GameObject.FindWithTag("Player");
            sayac sayac = player.GetComponentInChildren<sayac>();
            sayac.countdownTimer += 1;
        }
    }
