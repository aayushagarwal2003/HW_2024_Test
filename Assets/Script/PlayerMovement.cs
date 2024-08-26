
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameManager gameManager;
    public float raycastDistance = 1.0f;
    public LayerMask pulpitLayer;

    private Vector3 moveDirection;
    private GameObject currentPulpit;

    void Update()
    {
        HandleMovement();
        CheckForPulpitBelow();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void CheckForPulpitBelow()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, pulpitLayer))
        {

            if (hit.collider.CompareTag("Pulpit"))
            {

                if (hit.collider.gameObject != currentPulpit)
                {
                    currentPulpit = hit.collider.gameObject;
                    gameManager.UpdateScore();


                }
            }
        }
        else
        {

            currentPulpit = null;
        }
    }
}