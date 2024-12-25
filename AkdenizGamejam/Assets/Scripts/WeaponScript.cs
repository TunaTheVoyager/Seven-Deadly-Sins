using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace gameJam
{
    public class WeaponScript : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private float _bulletSpeed;
        private Vector3 oneAl = new Vector3(0, 0, 1);

        [SerializeField] private Transform sag;
        [SerializeField] private Transform sol;
        [SerializeField] private Transform ust;
        [SerializeField] private Transform alt;

        [SerializeField] public AudioClip weapon;

        private float atesAraligi = 15;



        private AudioSource _audShoot;

        private void Awake()
        {
            _audShoot = GetComponent<AudioSource>();
            
        }


        private void Update()
        {
            _bullet = GetComponentInChildren<bulletTut>().bullet;
            if (CompareTag("Enemy"))
            {
                atesAraligi += Time.deltaTime;
                if (atesAraligi > 5)
                {
                    EnemyShootAll();
                    atesAraligi = 0;
                }
            }
            
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _bullet = GetComponentInChildren<bulletTut>().bullet;
                var bulletUp = _bullet =
                    Instantiate(_bullet, ust.position, ust.rotation);
                bulletUp.GetComponent<Rigidbody2D>().velocity = ust.up * _bulletSpeed;
                _audShoot.clip = weapon;
                _audShoot.Play();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _bullet = GetComponentInChildren<bulletTut>().bullet;
                var bulletDown = _bullet = Instantiate(_bullet, alt.position,
                    alt.rotation);
                bulletDown.GetComponent<Rigidbody2D>().velocity = -alt.up * _bulletSpeed;
                _audShoot.clip = weapon;
                _audShoot.Play();

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _bullet = GetComponentInChildren<bulletTut>().bullet;
                var bulletLeft = _bullet = Instantiate(_bullet, sol.position,
                    sol.rotation);
                bulletLeft.GetComponent<Rigidbody2D>().velocity = -sol.right * _bulletSpeed;
                _audShoot.clip = weapon;
                _audShoot.Play();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _bullet = GetComponentInChildren<bulletTut>().bullet;
                var bulletRight = _bullet = Instantiate(_bullet, sag.position,
                    sag.rotation);
                bulletRight.GetComponent<Rigidbody2D>().velocity = sag.right * _bulletSpeed;
                _audShoot.clip = weapon;
                _audShoot.Play();
            }
        }
        public void EnemyShootAll()
        {
            EnemyShootDown();
            EnemyShootLeft();
            EnemyShootRight();
            EnemyShootUp();
        }

        public void enemyShotAll(GameObject _bullet, Transform _bulletSpawnPoint, float _bulletSpeed, Vector3 oneAl)
        {
            var bulletUp = _bullet =
                Instantiate(_bullet, _bulletSpawnPoint.position - oneAl, _bulletSpawnPoint.rotation);
            bulletUp.GetComponent<Rigidbody2D>().velocity = _bulletSpawnPoint.up * _bulletSpeed;

            var bulletDown = _bullet = Instantiate(_bullet, _bulletSpawnPoint.position - oneAl,
                _bulletSpawnPoint.rotation);
            bulletDown.GetComponent<Rigidbody2D>().velocity = -_bulletSpawnPoint.up * _bulletSpeed;

            var bulletLeft = _bullet = Instantiate(_bullet, _bulletSpawnPoint.position - oneAl,
                _bulletSpawnPoint.rotation);
            bulletLeft.GetComponent<Rigidbody2D>().velocity = -_bulletSpawnPoint.right * _bulletSpeed;

            var bulletRight = _bullet = Instantiate(_bullet, _bulletSpawnPoint.position - oneAl,
                _bulletSpawnPoint.rotation);
            bulletRight.GetComponent<Rigidbody2D>().velocity = _bulletSpawnPoint.right * _bulletSpeed;
        }
            public void playShootingSound()
            {
                _audShoot.Play();
            }
            
            public void EnemyShootUp()
            {
                var bulletUp = _bullet =
                    Instantiate(_bullet, ust.position - oneAl, ust.rotation);
                bulletUp.GetComponent<Rigidbody2D>().velocity = ust.up * _bulletSpeed;
            }

            public void EnemyShootDown()
            {
                var bulletDown = _bullet = Instantiate(_bullet, alt.position - oneAl,
                    alt.rotation);
                bulletDown.GetComponent<Rigidbody2D>().velocity = -alt.up * _bulletSpeed;
            }

            public void EnemyShootLeft()
            {
                var bulletLeft = _bullet = Instantiate(_bullet, sol.position - oneAl,
                    sol.rotation);
                bulletLeft.GetComponent<Rigidbody2D>().velocity = -sol.right * _bulletSpeed;
            }

            public void EnemyShootRight()
            {
                var bulletRight = _bullet = Instantiate(_bullet, sag.position - oneAl,
                    sag.rotation);
                bulletRight.GetComponent<Rigidbody2D>().velocity = sag.right * _bulletSpeed;
            }
    }
}
