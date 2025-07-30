using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalParticle : MonoBehaviour
{
    public GameObject goalParticleFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 contactPosition = contactPoint.point;
            Debug.Log("contact position: " + contactPosition);
            GameObject fx = Instantiate(goalParticleFX, contactPosition, Quaternion.identity);
            fx.GetComponent<ParticleSystem>().Play();
            Destroy(fx, 2f);
        }
    }
}
