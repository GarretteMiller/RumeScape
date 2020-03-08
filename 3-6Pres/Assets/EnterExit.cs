
using UnityEngine;
using UnityEngine.UI;

public class EnterExit : MonoBehaviour
{
    public Vector3 RespawnPos;
    public Quaternion RespawnRot;
    private bool menuActive;
    public Vector3 BuildingPOS;
    public Quaternion BuildingROT;
    public float speed = 1.0f;
    [SerializeField]
    public GameObject Arrow;
    public Transform originalParent;
    [SerializeField]
    private GameObject Building;
    [SerializeField]
    public Transform RespawnPoint;
    [SerializeField]
    private GameObject RespawnObject;
    private Animator animator;
    //public bool doorLocked;
    public bool KeyinUI;
    [SerializeField]
    private GameObject NextLevelUI;
    [SerializeField]
    private Button NextLevel;
    [SerializeField]
    private Button MainMenu;
    public DoorIn Doorin;
    public CountDown count;
    private bool gotonext;

    private void Awake()
    {
        NextLevel.onClick.AddListener(GoToNext);
        MainMenu.onClick.AddListener(GoToMain);

    }
    void Start()
    {
        //doorLocked = false;
        animator = GetComponent<Animator>();
        KeyinUI = false;
        gotonext = false;
    }
    private void Update()
    {
        //KeyinUI = GameObject.FindGameObjectWithTag("Something").GetComponent<Something>().something;
        if (count.levelFail == true)
        {
            KeyinUI = true;
        }
        if(gotonext==true && Arrow.activeSelf)
        {
            //RotateArrow();
        }
        //doorLocked = GameObject.FindGameObjectWithTag("DoorIn").GetComponent<DoorLeave>().doorLocked;

    }
    private void RotateArrow()
    {
            Vector3 targetDirection = Vector3.Normalize(RespawnPoint.position - Arrow.transform.position);
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(Arrow.transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(RespawnPoint.transform.position, targetDirection, Color.red);
            Arrow.transform.rotation = Quaternion.LookRotation(newDirection) * Quaternion.Euler(0, 90, 0);
            Vector3 arrowAngles = Arrow.transform.rotation.eulerAngles;
            arrowAngles.z = 0;
            arrowAngles.x = 0;
            Arrow.transform.rotation = Quaternion.Euler(arrowAngles);
    }
    private void GoToNext()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            gotonext = true;
            NextLevelUI.SetActive(false);
            originalParent = RespawnObject.transform.parent;
            RespawnObject.transform.parent = null;
            Building.SetActive(false);
            RespawnObject.SetActive(true);
            RespawnPos = RespawnPoint.position;
            RespawnRot = RespawnPoint.rotation;
            //Destroy(RespawnObject);
            //Instantiate(RespawnObject2, RespawnPos, RespawnRot);
            BuildingPOS = Building.transform.position;
            BuildingROT = Building.transform.rotation;
            /*Arrow.SetActive(true);
            if (!Arrow.activeSelf)
            {
                Arrow.SetActive(true);
                //ArrowActive = true;
            }
            */
        
    }
    private void GoToMain()
    {
        //SceneManager.LoadScene("ARStart"); 
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
             if (Doorin.doorLocked != true)
            {
                animator.SetTrigger("Open");
                Debug.Log("This works");
            }
            if (KeyinUI == true)
            {
                NextLevelUI.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
           if(Doorin.lvlInProg!=true)
            {
                animator.SetTrigger("Close");
            }
        
    }

}
