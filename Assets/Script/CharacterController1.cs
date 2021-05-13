using UnityEngine; 

namespace MarkParker.Scripts
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float charSpeed = 0.5f;
        [SerializeField] private float charJumpForce = 0.5f;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _newForce;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            // Getting input from user
            var horzMovement = Input.GetAxisRaw("Horizontal") * charSpeed;
            var jumpMovement = Input.GetAxisRaw("Jump") * charJumpForce;

            var charscale = transform.localScale;

            // if(horzMovement < 0) flipScale = Mathf.abs(charscale.x);
            //  else flipScale = -Mathf.abs(charscale.x);
            var flipScale = horzMovement < 0 ? -Mathf.Abs(charscale.x) : Mathf.Abs(charscale.x);
            transform.localScale = new Vector3(flipScale, charscale.y, charscale.z);
            //          (1,0)                          (0,1)
            _newForce = Vector2.right * horzMovement + Vector2.up * jumpMovement;
            
          
        }

        private void FixedUpdate()
        {
            //Make the GameObject travel upwards

            //Use Impulse mode as a force on the RigidBody
            _rigidbody2D.AddForce(_newForce, ForceMode2D.Impulse);
        }
    }
}