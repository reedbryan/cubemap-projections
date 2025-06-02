using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    public Animation animator;

    public float minRotationX = -30f; // Minimum rotation on the X-axis
    public float maxRotationX = 30f;  // Maximum rotation on the X-axis
    public float minRotationY = -45f; // Minimum rotation on the Y-axis
    public float maxRotationY = 45f;  // Maximum rotation on the Y-axis
    public float moveSpeed = 5f;      // Speed of movement

    void Start()
    {
        // Set a random rotation on the X and Y axes
        float randomX = Random.Range(minRotationX, maxRotationX);
        float randomY = Random.Range(minRotationY, maxRotationY);
        transform.rotation = Quaternion.Euler(randomX, randomY, 0f);
    }

    void Update()
    {
        // Move the transform forward based on its current rotation
        transform.position += transform.forward * -1f * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dive();
        }
    }

    void Dive()
    {
        if (animator != null)
        {
            animator.Blend("dive"); // Play the "dive" animation
            Debug.Log("Dive animation played");
        }

        StartCoroutine(
            DiveCoroutine(
                Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z)
                , diveDuration
                , "fastswim2" // Animation to play when surfacing
            )
        );
    }
    public float diveDuration;
    IEnumerator DiveCoroutine(Quaternion targetRotation, float duration, string animationName)
    {
        Quaternion startRotation = transform.rotation;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure it ends exactly at the target rotation

        if (animator != null)
        {
            animator.Blend(animationName); // Play the "fastswim" animation for surfacing
            Debug.Log($"{animationName} animation played");
        }

    }
}