using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 5f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private Transform[] _waypoints;

    private bool isJumping = false;

    void Update()
    {
        transform.position += GetMovement() * velocity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(JumpCoroutine());
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)) transform.position = _waypoints[0].position;
        if(Input.GetKeyDown(KeyCode.Alpha2)) transform.position = _waypoints[1].position;
        if(Input.GetKeyDown(KeyCode.Alpha3)) transform.position = _waypoints[2].position;
    }

    private Vector3 GetMovement()
    {
        float horizontalDir = Input.GetAxis("Horizontal");
        float verticalDir = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(-verticalDir, 0, horizontalDir);

        return direction.normalized;
    }

    private IEnumerator JumpCoroutine()
    {
        isJumping = true;

        float jumpTime = 0.5f; // Duración del salto
        float elapsedTime = 0f;

        while (elapsedTime < jumpTime)
        {
            transform.position += Vector3.up * jumpForce * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = _waypoints[0].position;
    }
}