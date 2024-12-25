using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sayac : MonoBehaviour
{
    [SerializeField] private GameObject kapi;
    public Text countdownText; // Geri sayım metnini gösterecek UI text nesnesi
    public float countdownDuration = 25f; // Geri sayım süresi

    public float countdownTimer; // Geri sayım süresini tutacak değişken


    private void Start()
    {
        countdownTimer = countdownDuration; // Geri sayım süresini başlatma
    }
    

    private void Update()
    {
        countdownTimer -= Time.deltaTime; // Geri sayım süresini azaltma
        

        if (countdownTimer > 0 )
        {
            countdownText.text = Mathf.CeilToInt(countdownTimer).ToString();
        }
        else if(countdownTimer < 0 || countdownTimer == 0)
        {
            Destroy(kapi);
            countdownTimer = 0;
            countdownText.text = "0";
        }

        if (countdownTimer==0)
        {
            Destroy(kapi);
        }
        
        if (countdownText.text == "0")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            countdownTimer = 10;
        }
        
        if (countdownTimer <= 0f)
        {
            countdownTimer = 0f;
        }
        
    }
    
    public float fontSize = 20f; // Yazı tipi boyutunu ayarlamak için kullanılacak boyut

    private GUIStyle guiStyle = new GUIStyle();

    private void OnGUI()
    {
        guiStyle.fontSize = Mathf.RoundToInt(fontSize);
        GUI.Label(new Rect(100, 5, 400, 400), "Saniye: " + Mathf.CeilToInt(countdownTimer).ToString(),guiStyle);
    }
}
