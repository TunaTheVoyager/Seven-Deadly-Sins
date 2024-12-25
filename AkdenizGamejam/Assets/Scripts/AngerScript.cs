using UnityEngine;
using UnityEngine.UI;

namespace gameJam
{
    public class AngerScript : MonoBehaviour
    {
        private float timer = 0f;
        private Rigidbody2D rb;
        [SerializeField] private Slider slider;
        private PlayerController playerController;
        private Image fillImage;

        [Header("Slider Values")]
        private float minValue;
        private float maxValue;

        [SerializeField] private float normalSpeed;
        private float stunedSpeed;

        //[SerializeField] private float transitionSpeed = 0.1f;

        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            slider.onValueChanged.AddListener(OnSliderValueChanged);
            fillImage = slider.fillRect.GetComponent<Image>();
            playerController = FindObjectOfType<PlayerController>();

            minValue = slider.minValue;
            maxValue = slider.maxValue;

            stunedSpeed = normalSpeed / 10f;
        }

        void FixedUpdate()
        {
            UpdateTimer();
            slider.value = timer;

            if (timer >= maxValue)
            {
                playerController.speed = stunedSpeed;
            }
            else if (timer <= minValue)
            {
                playerController.speed = normalSpeed;
            }
        }

        private bool IsMoving()
        {
            return rb.velocity != Vector2.zero;
        }

        private void UpdateTimer()
        {
            if (IsMoving() && timer < maxValue)
            {
                timer += Time.deltaTime;
            }
            else if (!IsMoving() && timer > minValue)
            {
                timer -= Time.deltaTime;
            }
        }

        private void OnSliderValueChanged(float value)
        {
            float normalizedValue = Mathf.Clamp01(timer / maxValue);

            float red = Mathf.Clamp01(normalizedValue);
            float green = Mathf.Clamp01(1f - normalizedValue);

            fillImage.color = new Color(red, green, 0f);
        }
    }
}
