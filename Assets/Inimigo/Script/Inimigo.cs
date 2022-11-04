using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Inimigo : MonoBehaviour
{
    private Animator animInimigo;
    private NavMeshAgent navMesh;
    private GameObject player;
    public float velocidadeInimigo;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animInimigo = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        navMesh.speed = velocidadeInimigo;

    }

    // Update is called once per frame
    void Update()
    {
        navMesh.destination = player.transform.position;
        animInimigo.SetBool("walk", true);

        if (Vector3.Distance(transform.position, player.transform.position) < 1.2f)
        {
            navMesh.speed = 0;
            animInimigo.SetBool("attack", true);
            StartCoroutine("ataque");
        }
    }

    IEnumerator ataque()
    {
        yield return new WaitForSeconds(0.2f);
        animInimigo.SetBool("attack", false);
        yield return new WaitForSeconds(2.8f);
        navMesh.speed = velocidadeInimigo;
    }
}
