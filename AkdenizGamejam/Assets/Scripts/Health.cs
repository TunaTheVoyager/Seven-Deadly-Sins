using gameJam;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour 
{
    [FormerlySerializedAs("_maximumHealth")] [SerializeField] private int maximumHealth = 5;
    [FormerlySerializedAs("_currentHealth")] public int currentHealth;
    public int healAmound = 1;
    [FormerlySerializedAs("_gm")] public GameManager gm;
    [FormerlySerializedAs("_dl")] public DropLoot dl;

    [FormerlySerializedAs("_healSound")] [SerializeField] private AudioClip healSound;
    [FormerlySerializedAs("_deathSound")] [SerializeField] private AudioClip deathSound;


    private void Start()
    {
        gm = gameObject.AddComponent<GameManager>();
        currentHealth = maximumHealth;
    }
        
    override public string ToString()
    {
        return currentHealth + " / " + maximumHealth;
    }



    public virtual void Death()
    {
        if (currentHealth<0)
        {
            currentHealth = 0;
        }
        
        if ( currentHealth== 0) 
        {
            if (CompareTag("Player"))
            {
                // Animator a = GetComponentInChildren<Animator>();
                gm.restartScene();
            }

            if (CompareTag("Enemy"))
            {
                Destroy(this.gameObject);
                dl.OnDeath();
            }
        }
    }

    private void Update()
    {
        Death();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public virtual void Heal(int hp)
    {
        currentHealth += hp;

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
        
        if (healSound != null)
        {
            GetComponent<AudioSource>().clip = healSound;
            GetComponent<AudioSource>().Play();
        }
    }
}