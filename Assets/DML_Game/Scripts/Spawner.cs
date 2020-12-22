using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float waitTime = 10f;
    public GameObject zombie;

    void Start()
    {
        Invoke("Spawn", waitTime);
    }

    void Spawn()
    {
        Instantiate(zombie, transform.position, transform.rotation);
        if(waitTime > .2f)
        {
            waitTime -= .2f;
        }
        Invoke("Spawn", waitTime);
    }
}
