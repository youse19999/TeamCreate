using UnityEngine;

public class LiftScript : MonoBehaviour
{
    [SerializeField]private float speed = 10.0f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
