using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject exitPortal;
    private Transform exitPortalExitSpace;
    private BoxCollider portalCollider;
    private BoxCollider exitPortalCollider;
    private Vector3 heading;
    private float forwardOffset = 1.0f;
    private float cooldownTime = 1f;
    private bool isTriggered = false;  

    void Start()
    {
        // Cache the BoxCollider components
        portalCollider = GetComponent<BoxCollider>();
        exitPortalCollider = exitPortal.GetComponent<BoxCollider>();

        // Get local forward direction
        exitPortalExitSpace = exitPortal.transform.Find("PortalExitSpace");
        heading = exitPortalExitSpace.position - exitPortal.transform.position;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.gameObject.CompareTag("Player"))
        {
            isTriggered = true;

            // Disable colliders
            portalCollider.enabled = false;
            exitPortalCollider.enabled = false;

            // Calculate teleportation offset
            Vector3 offset = heading.normalized * forwardOffset;

            // Teleport player using adjusted offset
            other.gameObject.transform.position = exitPortal.transform.position + offset;

            // Adjust player momentum
            Rigidbody playerRb = other.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.velocity = heading.normalized * playerRb.velocity.magnitude;
            }

            // Start cooldown coroutine
            StartCoroutine(EnableCollidersAfterCooldown());
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    IEnumerator EnableCollidersAfterCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);

        // Enable colliders after cooldown
        isTriggered = false;
        portalCollider.enabled = true;
        exitPortalCollider.enabled = true;
    }
}
