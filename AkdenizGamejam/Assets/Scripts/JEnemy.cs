using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameJam
{
    
    public class JEnemy : MonoBehaviour

    {
        Transform player;
        private float time = 0;
        [SerializeField] float speed = 1f;
        private bool canDash = true;
        private bool isDashing;
        private float dashingPower = 24f;
        private float dashingTime = 0.2f;
        private float dashingCooldown = 1f;

        Rigidbody2D rb;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Timer();
            FindNewTargetPos();
        }
        
        void Timer()
        {
            time += Time.deltaTime;
            if (time >= 3)
            {
                if (canDash)
                {
                    StartCoroutine(Dash());
                    time = 0;
                }
            }
        }

        IEnumerator Dash()
        {
            canDash = false;
            isDashing = true;

            Vector2 direction = (player.position - transform.position).normalized;

            rb.velocity = direction * dashingPower;
            yield return new WaitForSeconds(dashingTime);

            rb.velocity = Vector2.zero;
            isDashing = false;

            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;
        }

        void FindNewTargetPos()
        {
            if (!isDashing && player != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
            }
        }
    }
}
