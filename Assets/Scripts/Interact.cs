using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public GameObject kickButton;
    private GameObject objectInRange;

    public float kickForce = 500f;

    public CameraController cameraController;

    public void Kick()
    {
        if (objectInRange == null) return;

        GameObject nearestGoal = FindNearestGoal(objectInRange.transform.position);
        if (nearestGoal == null) return;

        Rigidbody rb = objectInRange.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (nearestGoal.transform.position - objectInRange.transform.position).normalized;
            rb.AddForce(direction * kickForce);
            StartCoroutine(cameraController.FollowBall(objectInRange));
        }
    }

    public void AutoKick()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        GameObject farthestBall = null;
        float maxDistance = 0f;

        foreach (GameObject ball in balls)
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestBall = ball;
            }
        }

        if (farthestBall == null) return;

        GameObject nearestGoal = FindNearestGoal(farthestBall.transform.position);
        if (nearestGoal == null) return;

        Rigidbody rb = farthestBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (nearestGoal.transform.position - farthestBall.transform.position).normalized;
            rb.AddForce(direction * kickForce);
            StartCoroutine(cameraController.FollowBall(farthestBall));
        }
    }

    private GameObject FindNearestGoal(Vector3 fromPosition)
    {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goal");
        if (goals.Length == 0) return null;

        GameObject nearestGoal = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject goal in goals)
        {
            float distance = Vector3.Distance(fromPosition, goal.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestGoal = goal;
            }
        }

        return nearestGoal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            objectInRange = other.gameObject;
            kickButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            objectInRange = null;
            kickButton.SetActive(false);
        }
    }
}
