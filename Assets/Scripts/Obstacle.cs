using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float speed;
    [SerializeField] GameObject effect;
    Shake shake;
    [SerializeField] GameObject explosionSound;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
}