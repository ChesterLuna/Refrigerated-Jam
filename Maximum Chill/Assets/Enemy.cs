using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Enemy Stats")]
    [SerializeField] float health = 1;
    [SerializeField] public float speed = 2f;
    [SerializeField] public int pointValue = 100;


    [Header("Enemy SFX")]
    [SerializeField][Range(0, 1)] float audioVol = 0.14f;
    [SerializeField] float durationDeathVFX = 1f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip[] deathSFX;
    [SerializeField] float durationWinVFX = 1f;
    [SerializeField] GameObject winVFX;
    [SerializeField] AudioClip[] winSFX;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.FindWithTag("Player");
        MoveToPlayer();
    }


    private void MoveToPlayer()
    {
        var playerPosition = player.transform.position;
        var movementThisFrame = Time.deltaTime * speed;

        transform.LookAt(new Vector3(playerPosition.x, transform.position.y, playerPosition.z));
        Vector3 moveStep = Vector3.MoveTowards(transform.position, playerPosition, movementThisFrame);

        MoveFunc(moveStep);
        // ADD A RANGE, LIKE A SQUARE
        if (transform.position == playerPosition)
        {
            //Destroy(gameObject);
            //waypointIndex++;
        }
    }

    private void MoveFunc(Vector3 moveStep)
    {
        transform.position = moveStep;
        transform.position += transform.right * Mathf.Sin(Time.time * 2f) * 0.1f;
    }

    private void OnMouseDown()
    {
        Death();
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //ReachedPlayer();
    }

    private void ReachedPlayer()
    {
        Destroy(gameObject);
        GameObject destruction = Instantiate(winVFX, transform.position, transform.rotation);
        Destroy(destruction, durationWinVFX);

        int indexDeathSFX = Random.Range(0, deathSFX.Length);
        AudioSource.PlayClipAtPoint(deathSFX[indexDeathSFX], Camera.main.transform.position, audioVol);
    }

    private void Death()
    {

        Destroy(gameObject);

        GameObject destruction = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(destruction, durationDeathVFX);

        int indexDeathSFX = Random.Range(0, deathSFX.Length);
        AudioSource.PlayClipAtPoint(deathSFX[indexDeathSFX], Camera.main.transform.position, audioVol);

    }

}
