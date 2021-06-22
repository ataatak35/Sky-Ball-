using UnityEngine;

public class CameraController : MonoBehaviour{
    [SerializeField]private Transform player;
    [SerializeField]private float yOffset = 3.75f ;
    [SerializeField]private float xOffset = -3.5f;
    void Start(){
        player = GameObject.Find("Player").transform;
    }

    
    void LateUpdate(){
        transform.position = new Vector3(player.position.x + xOffset,player.position.y + yOffset, player.position.z);
    }
}
