using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int point;//1,2,3,10

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
