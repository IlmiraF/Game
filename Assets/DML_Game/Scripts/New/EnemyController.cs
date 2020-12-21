using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    private Transform player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(findPath());
        StartCoroutine(playerDetect());
    }

    IEnumerator playerDetect()
    {
        while(true)
        {
            if(player == null)
            {
                break;
            }
            if(Vector3.Distance(transform.position, player.position) < 10f)
            {
                animator.SetBool("Attack", true);
                player.SendMessage("damage");
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    IEnumerator findPath()
    {
        while(true)
        {
            if (player != null)
            {
                agent.SetDestination(player.position);
                yield return new WaitForSeconds(2f);
            }
            else
            {
                break;
            }
        }
    }

    public void damage()
    {
        StopAllCoroutines();
        agent.enabled = false;
        animator.SetTrigger("Die");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 5f);
        GameManager.instance.deadUnit(gameObject);
    }
}
