using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gameJam
{
    public class UEnemy : MonoBehaviour
    {
        Transform player; // Oyuncunun pozisyonunu takip eder
        public float attackRange = 5f; // Sald�r� mesafesi
        public float stopRange = 2f; // Sald�r�y� durdurma mesafesi
        public float moveSpeed = 2f; // Hareket h�z�
        public int health = 100; // D��man�n can�

        public Vector2 targetPos; // Vector3'� Vector2 ile de�i�tirdik
        public bool isMoving = false;
        public float maxRange = 10f;
        public float waitTime = 3f;
        public float roamSpeed = 0.05f; // Do�a�lama hareket h�z�

        private bool isAttacking = false;
        private float atesAraligi = 15;


        #region enemyShotAll

        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _bulletSpeed;
        private Vector3 oneAl = new Vector3(0, 0, 1);

        #endregion 

        


        void Update()
        {
            atesAraligi += Time.deltaTime;
            if (atesAraligi > 5)
            {
                EnemyShootAll();
                atesAraligi = 0;
            }

            
            player = GameObject.FindGameObjectWithTag("Player").transform;
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange && distanceToPlayer > stopRange)
            {
                // Oyuncuya do�ru hareket et ve oyuncuya odaklan
                MoveTowardsPlayer();
                FocusOnPlayer();
                isMoving = false;
                StopCoroutine(Move());
                isAttacking = false;
            }
            else if (distanceToPlayer <= stopRange)
            {
                // Sald�r ve oyuncuya odaklan
                StopAndAttack();
                FocusOnPlayer();
                isMoving = false;
                StopCoroutine(Move());
            }
            else
            {
                // Do�a�lama hareket
                if (!isMoving)
                {
                    FindNewTargetPos();
                }
            }
        }

        public void EnemyShootAll()
        {
            EnemyShootDown();
            EnemyShootLeft();
            EnemyShootRight();
            EnemyShootUp();
        }

        
        
        public void EnemyShootUp()
        {
            var bulletUp = _bullet =
                Instantiate(_bullet, _bulletSpawnPoint.position - oneAl, _bulletSpawnPoint.rotation);
            bulletUp.GetComponent<Rigidbody2D>().velocity = _bulletSpawnPoint.up * _bulletSpeed;
        }

        public void EnemyShootDown()
        {
            var bulletDown = _bullet = Instantiate(_bullet, _bulletSpawnPoint.position - oneAl,
                _bulletSpawnPoint.rotation);
            bulletDown.GetComponent<Rigidbody2D>().velocity = -_bulletSpawnPoint.up * _bulletSpeed;
        }

        public void EnemyShootLeft()
        {
            var bulletLeft = _bullet = Instantiate(_bullet, _bulletSpawnPoint.position - oneAl,
                _bulletSpawnPoint.rotation);
            bulletLeft.GetComponent<Rigidbody2D>().velocity = -_bulletSpawnPoint.right * _bulletSpeed;
        }

        public void EnemyShootRight()
        {
            var bulletRight = _bullet = Instantiate(_bullet, _bulletSpawnPoint.position - oneAl,
                _bulletSpawnPoint.rotation);
            bulletRight.GetComponent<Rigidbody2D>().velocity = _bulletSpawnPoint.right * _bulletSpeed;
        }

        void MoveTowardsPlayer()
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        void StopAndAttack()
        {
            if (!isAttacking)
            {
                isAttacking = true; // Sald�r� animasyonu ve hasar verme i�lemleri burada yap�l�r
            }
        }

        void FocusOnPlayer()
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Z ekseni sabit tutulur
        }

        void FindNewTargetPos()
        {
            Vector2 pos = transform.position;
            targetPos = new Vector2();
            targetPos.x = Random.Range(pos.x - maxRange, pos.x + maxRange);
            targetPos.y = Random.Range(pos.y - maxRange, pos.y + maxRange);

            Vector2 direction = (targetPos - pos).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Z ekseni sabit tutulur
            StartCoroutine(Move());
        }

        IEnumerator Move()
        {
            isMoving = true;

            while (Vector2.Distance(transform.position, targetPos) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, roamSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
            isMoving = false;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Debug.Log("D��man �ld�!");
            Destroy(gameObject); // D��man� sahneden sil
        }
    }
}
