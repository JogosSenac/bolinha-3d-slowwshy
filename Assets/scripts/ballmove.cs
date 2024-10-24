 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ballmove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcejump;
    public GameObject cubecoin;
    public TextMeshProUGUI coinColeted;
    [SerializeField] private int CoinsColector = 0;
    private bool Jumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
         
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        transform.position += new Vector3(moveV * velocidade * Time.deltaTime, 0, -1 * moveH * velocidade * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && Jumping == false)
        {
        
            rb.AddForce(transform.up * forcejump, ForceMode.Impulse);
            Jumping = true;
        }
        coinColeted.text =  CoinsColector.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CoinsColector ++ ;
        }
        if(other.gameObject.CompareTag("Portal") && CoinsColector == 12)
        {
            SceneManager.LoadScene(2);
        }
        if(other.gameObject.CompareTag("Portal2"))
        {
            SceneManager.LoadScene(4);
        }
    }

    private void OnCollisionEnter(Collision other)
    {

    if(other.gameObject.CompareTag("Lava"))
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(3);
    }
    if(other.gameObject.CompareTag("chao"))
    {
        Jumping = false;
    }
    
    }
       

   
}
