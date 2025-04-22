using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public float minforce = 10f;
    public float maxForce = 14f;
    private Rigidbody2D rig;

    public GameObject fruitCut;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(transform.up * Random.Range(minforce, maxForce), ForceMode2D.Impulse);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Blade")
        {
            
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitCut, transform.position, rotation);
            AudioController.instance.PlayMusic(AudioController.instance.Slice);
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }
}
