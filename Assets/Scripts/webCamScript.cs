using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class webCamScript : MonoBehaviour
{

    public GameObject webCameraPlane;
    public Button fireButton;
    private bool isCollider = false;
    private bool startBullet = false;
    collison col;
    GameObject bullet = null;
    public int score;
    [SerializeField]
    public Text text;
    public GameObject image;

    // Use this for initialization
    void Start()
    {
        image.SetActive(false);
        //text = GetComponent<Text>();
        text.text = "Score  " + score;
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;

        fireButton.onClick.AddListener(OnButtonDown);


        WebCamTexture webCameraTexture = new WebCamTexture();
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
        webCameraTexture.Play();




    }


    void OnButtonDown()
    {
        startBullet = true;
        bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.transform.position = Camera.main.transform.position;
        rb.AddForce(Camera.main.transform.forward * 500f);
        Destroy(bullet, 3);
        //startBullet = false;

        col = bullet.GetComponent<collison>();
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (startBullet)
        {
            if (col != null)
            {
                col = bullet.GetComponent<collison>();

                if (col.isCollider)
                {
                    print("1");
                    score += col.score;
                    Destroy(bullet);
                    startBullet = false;
                    print(startBullet);
                    if (col.islast)
                    {
                        image.SetActive(true);
                    }
                }
            }
            
        }
        text.text = "Score  " + score;
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;

    }
}