using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  
    public int currentHealth;    
    public Image healthBar;      
    public int damageAmount = 10;  
    public AudioSource src;
    public AudioClip hurtSFX;
    public Animator bloodAnim;

    public static bool hasSword = false;

    public static bool canSwing = true;

    public Animator swordAnim;

    public BoxCollider swordHitbox;

    private Rigidbody rb;

    public static bool isInside = false;

    void Start()
    {
        isInside = false;
        swordHitbox.enabled = false;
        canSwing = true;
        hasSword = false;
        currentHealth = maxHealth;
        UpdateHealthBar();

        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Debug.Log(isInside);
        if (NPCDialogue.isInDialogue || SwordFunctionality.isInDialogue) {
            rb.velocity = Vector3.zero;
            return;
        }

        if (!canSwing) {
            swordHitbox.enabled = true;
        }
        else {
            swordHitbox.enabled = false;
        }

        if (currentHealth == 0) {
            SceneManager.LoadScene("gameover");
        }


        if (hasSword && canSwing && Input.GetMouseButtonDown(0)) {
            swordAnim.SetTrigger("swing");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damageAmount);
        }
    }
    void OnCollisionExit(Collision collision)
    {
    }
//=================================================
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Church"))
        {
            isInside = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Church"))
        {
            isInside = false;
        }
    }






    void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        

        //src.PlayOneShot(hurtSFX);
        bloodAnim.SetTrigger("hurt");
        UpdateHealthBar();

        // check for player death
        if (currentHealth <= 0)
        {
            Debug.Log("Player has died!");
          
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }
}
