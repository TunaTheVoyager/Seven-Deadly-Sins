using System;
using gameJam;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LazyScript : MonoBehaviour
{
    [SerializeField] TMP_Text countText; // Sayaç metnini tutar
    [SerializeField] float countDown; // Geri sayım süresini tutar
    private float timer = 0f; // Zamanlayıcıyı tutar
    private Rigidbody2D rb; // Rigidbody2D bileşenini tutar
    [SerializeField] private Slider slider; // Slider bileşenini tutar
    private PlayerController playerController; // PlayerController bileşenini tutar
    private Image fillImage; // Slider'ın dolum görüntüsünü tutar

    [Header("Slider Values")] private float minValue; // Slider'ın minimum değerini tutar
    private float maxValue; // Slider'ın maksimum değerini tutar

    [SerializeField] private float normalSpeed; // Normal hız değerini tutar
    private float stunedSpeed; // Yavaşlatılmış hız değerini tutar

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini alır
        slider.onValueChanged.AddListener(OnSliderValueChanged); // Slider değer değişikliği olayına dinleyici ekler
        fillImage = slider.fillRect.GetComponent<Image>(); // Slider'ın dolum görüntüsünü alır
        playerController = FindObjectOfType<PlayerController>(); // PlayerController bileşenini bulur

        minValue = slider.minValue; // Slider'ın minimum değerini alır
        maxValue = slider.maxValue; // Slider'ın maksimum değerini alır

        stunedSpeed = normalSpeed / 2; // Yavaşlatılmış hızı hesaplar
    }

    public void FixedUpdate()
    {
        UpdateTimer(); // Zamanlayıcıyı günceller
        slider.value = countDown; // Slider değerini günceller

        if (timer >= maxValue) // Zamanlayıcı maksimum değere ulaştığında
        {
            playerController.speed = stunedSpeed; // Oyuncu hızını yavaşlatır
            countDown += Time.deltaTime; // Geri sayımdan 1 saniye arttırır
            countText.text = Math.Round(countDown).ToString(); // Geri sayımı günceller
        }
        else if (timer <= minValue) // Zamanlayıcı minimum değere ulaştığında
        {
            playerController.speed = normalSpeed; // Oyuncu hızını normale döndürür
        }

        if (countDown >= 0) // Geri sayım sıfırdan büyük olduğu sürece
        {
            countText.text = Math.Round(countDown -= Time.deltaTime).ToString(); // Geri sayımı günceller
        }
    }

    private bool IsMoving()
    {
        return rb.velocity != Vector2.zero; // Nesnenin hareket edip etmediğini kontrol eder
    }

    private void UpdateTimer()
    {
        if (IsMoving() && timer < maxValue) // Nesne hareket etmiyorsa ve zamanlayıcı maksimum değerden küçükse
        {
            timer += Time.deltaTime; // Zamanlayıcıyı artırır
        }
        else if (!IsMoving() && timer > minValue) // Nesne hareket ediyorsa ve zamanlayıcı minimum değerden büyükse
        {
            timer -= Time.deltaTime; // Zamanlayıcıyı azaltır
        }
    }

    private void OnSliderValueChanged(float value)
    {
        float normalizedValue = Mathf.Clamp01(timer / maxValue); // Zamanlayıcıyı normalleştirir

        float red = Mathf.Clamp01(normalizedValue); // Kırmızı bileşeni hesaplar
        float green = Mathf.Clamp01(1f - normalizedValue); // Yeşil bileşeni hesaplar

        fillImage.color = new Color(red, green, 0f); // Dolum rengini ayarlar
    }
}
