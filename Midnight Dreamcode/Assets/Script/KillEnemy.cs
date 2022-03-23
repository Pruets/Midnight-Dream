using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Rigidbody2D rbPlayer;

    [SerializeField] private GameObject pop;

    private void Awake()
    {
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 5);
            //enemy.SetActive(false);
            Destroy(enemy);
            Instantiate(pop, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

}
