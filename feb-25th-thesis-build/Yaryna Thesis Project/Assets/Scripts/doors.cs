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
            if (playsSound)
            {
                src.PlayOneShot(doorSound);
            }

            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false; 
            }

            Vector3 localForward = player.transform.forward;

            player.transform.position = teleportDestination.position;


            player.transform.forward = teleportDestination.TransformDirection(localForward);

            if (controller != null)
            {
                controller.enabled = true;
            }
        }
    }
}
