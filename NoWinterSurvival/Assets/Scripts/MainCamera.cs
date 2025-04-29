using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;

    private void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 1, -5);
    }

}
