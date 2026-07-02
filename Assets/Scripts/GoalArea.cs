using UnityEngine;

public class GoalArea : MonoBehaviour
{
    BoxCollider boxCollider;
    [SerializeField]GameObject targetPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == targetPlayer)
        {
            Debug.Log("ì¸ÇËÇ‹ÇµÇΩÅB");
        }
    }
}
