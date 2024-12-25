using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ileriGeri : MonoBehaviour
{
    public float hareketHizi = 5f; // Düşmanın hareket hızı
    public Transform solDuvar; // Sol duvar objesi
    public Transform sagDuvar; // Sağ duvar objesi

    private bool sagaGidiyor = true; // Düşmanın başlangıçta sağa gitmesini sağlar

    void Update()
    {
        // Düşmanın sağa veya sola gitmesi gerektiğini belirler
        Vector3 yon = sagaGidiyor ? Vector3.right : Vector3.left;

        // Düşmanı ileri doğru hareket ettirir
        transform.Translate(yon * hareketHizi * Time.deltaTime);

        // Eğer düşman sağ duvara ulaştıysa veya sol duvara ulaştıysa yönünü değiştirir
        if ((sagaGidiyor && transform.position.x >= sagDuvar.position.x) ||
            (!sagaGidiyor && transform.position.x <= solDuvar.position.x))
        {
            sagaGidiyor = !sagaGidiyor;
        }
    }
}
                                                                        