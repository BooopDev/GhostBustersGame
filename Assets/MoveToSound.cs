using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MoveToSound : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    private Animator anim;
    public float rotationSpeed = 3;
    private bool canSeePlayer = false;
    public Transform[] randLocs;
    public bool canMove = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.1f)
        {
            anim.SetBool("isMoving", false);
        }
        if (canSeePlayer)
        {
            Follow();
        }
        if(GhostSight.inFov(transform, player.transform, 80, 11))
        {
            anim.SetBool("isMoving", true);
            Follow();
        }
        if(Vector3.Distance(transform.position, player.transform.position) < 0.75f && !EnterLocker.inLocker)
        {
            SceneManager.LoadScene("Level");
        }
    }

    public void Search(Transform targetPos)
    {
        if (!canSeePlayer)
        {
            agent.SetDestination(targetPos.position);
        }
    }

    public void Follow()
    {
        agent.SetDestination(player.transform.position);
    }

    private Quaternion newRot;

    public void RandomTurn()
    {
        StartCoroutine(RotateGhost());
    }

    public void RandomLocation()
    {
        if(canMove)
        {
            anim.SetBool("isMoving", true);
            agent.SetDestination(randLocs[Random.Range(0, randLocs.Length)].position);
            Invoke("RandomLocation", Random.Range(5f, 20f));
        }
        
    }

    public IEnumerator RotateGhost()
    {
        Debug.Log("turn");
        
        newRot = Random.rotation;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(newRot.x, 0, newRot.z));
        newRot = lookRotation;
        while (Quaternion.Angle(transform.rotation, newRot) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * rotationSpeed);
            yield return null;
        }
        Invoke("RandomTurn", Random.Range(2f, 10f));
        yield break;
    }
}
