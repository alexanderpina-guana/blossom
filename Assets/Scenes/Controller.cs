using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller: MonoBehaviour
{
    public static Controller Instance { get; private set; }

    [Header("Mouse Settings")]
    public float sensitivity = 100f;
    public float clampAngle = 85f;
    public float moveSpeed = 5f;

    [Header("KeyCode Bindings")]
    public KeyCode forwardKey;
    public KeyCode rollRight;
    public KeyCode rollLeft;
    public KeyCode shoot;


    private Pawn PawnScript;
    private BulletSettings BulletSettingsScript;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PawnScript = GetComponent<Pawn>();
        BulletSettingsScript = GetComponent<BulletSettings>();
    }

    void Update()
    {
        HandleMovementandDrag();
        rollLeftKey();
        rollRightKey();
        shootKey();
    }

 

    private void rollRightKey()
    {
        if(Input.GetKey(rollRight))
        {
            PawnScript.HandleRollRight();
        }
    }

    private void shootKey()
    {
        if (Input.GetKeyDown(shoot))
        {
            BulletSettingsScript.HandleShooting();
        }
    }

    private void rollLeftKey()
    {
        if(Input.GetKey(rollLeft))
        {
            PawnScript.HandleRollLeft();
        }
    }

    private void HandleMovementandDrag()
    {
      Vector3 movement = Vector3.zero;
      float yawInput;
      float pitchInput;

      if (Input.GetKey(KeyCode.W))
      {
        movement += transform.forward * moveSpeed;
      }
      if (Input.GetKey(KeyCode.S))
      {
        movement -= transform.forward * moveSpeed;
      }
      if (Input.GetKey(KeyCode.J))
      {
        yawInput = -1f;
      }
      if (Input.GetKey(KeyCode.L))
      {
        yawInput = 1f;
      }
      if (Input.GetKey(KeyCode.Z))
      {
        pitchInput = 1f;
      }
      if (Input.GetKey(KeyCode.C))
      {
        pitchInput = -1f;
      }
       else
        {
            PawnScript.ApplyDrag();
        }
    }
}
