using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 2.0f;  
    public float attackDistance = 1.5f;  
    private Transform player;  
    //private Animator anim;  //enemy anim
    public AudioSource src;
    public AudioClip deathSound;
    

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        

        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (NPCDialogue.isInDialogue) {
            return;
        }
        
        if (player != null)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);


            if (distanceToPlayer <= attackDistance)
            {
                //anim.SetTrigger("attakc");
            }
            else
            {

                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;

                transform.LookAt(player.position);
            }
        }
    }




    public void DisableCollider()
    {



    }

    public void EnableCollider()
    {



    }

}
