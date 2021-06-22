using UnityEngine;

public class Player : MonoBehaviour
{

    private float maxZ = 3.52f;
    private float maxY = 3.25f;
    private bool isOnTheRight;
    private bool isOnTheLeft;
    private bool isOnTheTop;
    void Start()
    {
        isOnTheRight = false;
        isOnTheLeft = false;
        isOnTheTop = false;

    }

    
    void Update()
    {

        if (transform.position.z >= maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 3.5f);

            isOnTheLeft = true;
            isOnTheTop = false;
            
            
        }

        if (transform.position.z <= -maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3.5f);
            
            isOnTheRight = true;
            isOnTheTop = false;
        }

        if (transform.position.y >= maxY)
        {
            transform.position = new Vector3(transform.position.x, 3.2f, transform.position.z);
            isOnTheTop = true;
        }
        
        //GAME OVER
        if (transform.position.y < 0.325f)
        {
            GameManager.Instance.GameOver();
        }
        
    }

    private void FixedUpdate()
    {

        if (isOnTheRight)
        {
            Debug.Log("1");
            PlayerController.rb.velocity = new Vector3(PlayerController.rb.velocity.x, 0, 0);
            PlayerController.rb.velocity =
                new Vector3(PlayerController.rb.velocity.x, PlayerController.rb.velocity.y - 10f, 0);

            isOnTheRight = false;
        }

        if (isOnTheLeft)
        {
            Debug.Log("2");
            PlayerController.rb.velocity = new Vector3(PlayerController.rb.velocity.x, 0, 0);
            PlayerController.rb.velocity =
                new Vector3(PlayerController.rb.velocity.x, PlayerController.rb.velocity.y - 10f, 0);
            isOnTheLeft = false;
        }

        if (isOnTheTop)
        {
            PlayerController.rb.velocity =
                new Vector3(PlayerController.rb.velocity.x, -10f, PlayerController.rb.velocity.z);
            isOnTheTop = false;
        }

    }

    private void OnTriggerEnter(Collider other){
        if (other.name == "FallTrigger"){
            Debug.Log("Tetiklendi");
        }
    }
    
}
