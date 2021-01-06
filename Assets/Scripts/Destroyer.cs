using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}