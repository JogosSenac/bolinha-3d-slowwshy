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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * forcejump, ForceMode.Impulse);
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
        if(other.gameObject.CompareTag("Portal") && CoinsColector == 13)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionEnter(Collision other)
    {

    if(other.gameObject.CompareTag("Lava"))
    {
        Destroy(this.gameObject);
    }
    
    }
       

   
}
