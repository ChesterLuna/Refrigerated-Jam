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
        
        //var lastw = transform.rotation.w;
        transform.LookAt(playerPosition);
        transform.rotation = new Quaternion(0,0,transform.rotation.z, transform.rotation.w);
        transform.GetChild(0).transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);

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
        float freq = 3f;
        float magn = 0.01f;
        transform.position = moveStep;
        transform.position += transform.up * Mathf.Sin(Time.time * freq) * magn;
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
        FindObjectOfType<GameSession>().AddToScore(pointValue);

        Destroy(gameObject);

        if(true) {return;}
        GameObject destruction = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(destruction, durationDeathVFX);

        int indexDeathSFX = Random.Range(0, deathSFX.Length);
        AudioSource.PlayClipAtPoint(deathSFX[indexDeathSFX], Camera.main.transform.position, audioVol);

    }

}
