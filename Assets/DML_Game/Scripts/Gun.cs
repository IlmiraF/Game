using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource audio;
    public float waitTime = .15f;
    private float wait = 0f;

    public void shoot()
    {
        if(wait <= 0f)
        {
            wait = waitTime;
            audio.Play();

            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if(hit.collider.tag == "Enemy")
                {
                    hit.transform.SendMessage("damage");
                }
            }
        }
    }

    void Update()
    {
        if(wait > 0)
        {
            wait -= Time.deltaTime;
        }
    }
}
