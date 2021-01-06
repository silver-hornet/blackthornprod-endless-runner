using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector2 targetPos;
    [SerializeField] float yIncrement;
    [SerializeField] float speed;
    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;
    public int health = 3;
    [SerializeField] GameObject effect;
    Shake shake;
    [SerializeField] Text healthDisplay;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject popSound;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(popSound, transform.position, Quaternion.identity);
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(popSound, transform.position, Quaternion.identity);
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            transform.position = targetPos;
        }
    }
}