using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Transform teleportDestination;
    public GameObject player; 
    
    public bool playsSound;
    public AudioSource src;
    public AudioClip doorSound;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == player)
        {
            if (playsSound) {
                src.PlayOneShot(doorSound);
            }
            
            player.transform.position = teleportDestination.position;
            player.transform.rotation = teleportDestination.rotation; 
        }
    }
}
