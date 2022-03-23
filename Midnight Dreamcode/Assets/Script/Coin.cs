using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject pop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GamePlay.instance.getCoin(1);
            gameObject.SetActive(false);
            Instantiate(pop, new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
        }
    }
    
}
