using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takipEt : MonoBehaviour
{
    public Transform player; // Oyuncunun pozisyonunu tutmak için kullanılacak transform

    public float moveSpeed = 5f; // Objenin hareket hızı

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        if (player != null) // Eğer oyuncu varsa
        {
            // Objeyi oyuncunun pozisyonuna doğru hareket ettirme
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}


