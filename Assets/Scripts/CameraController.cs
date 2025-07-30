using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerTarget;
    private GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = playerTarget;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(currentTarget != null)
        {
            transform.position = new Vector3(currentTarget.transform.position.x, currentTarget.transform.position.y + 10.0f, currentTarget.transform.position.z);
        }
    }

    public IEnumerator FollowBall(GameObject ball)
    {
        currentTarget = ball;

        yield return new WaitForSeconds(2);

        currentTarget = playerTarget;
    }
}