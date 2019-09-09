using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chef_script : MonoBehaviour
{
    public float force = 65f;
    private Vector3 moveTo;
    private Rigidbody rb;
    private Animator chefWalk;
    private cerca cercaDetection;
    private holder myPlayerHolder;
    private bool IsChopping = false;
    public GameObject objeto;
    private plate Plate;
    private NewTable nuevo;

    public GameObject objeto_pot;
    private float pot_number;
    public GameObject humo;
    public float segundos = 0.0f;
    int marcador = 0;
    float puntos = 0;
    public Text puntaje;
    public Text tiempoPantala;
    float targetTime = 220.0f;
    private entrega Entrega;
    int numero1;

    public AudioSource grab;
    public AudioSource drop;
    public AudioSource Alarm;
    public AudioSource bad;
    public AudioSource good;
    public AudioSource endSound;
    public AudioSource background; 

    public foodType T;
    public foodType O;
    public foodType M;
    public GameObject plato;
    public GameObject empty;
    public GameObject PlateTomato;
    public GameObject PlateCebolla;
    public GameObject PlateMushroom;
    public GameObject PlateBad;
    public GameObject potBurned;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cercaDetection = GetComponent<cerca>();
        myPlayerHolder = GetComponent<holder>(); 
        chefWalk = GetComponent<Animator>();
        Plate = GetComponent<plate>();
        humo.SetActive(false);
        Entrega = GetComponent<entrega>();
    }

    // Update is called once per frame
    public void Update()
    {
        
        timer();
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        moveTo = new Vector3(horizontalMove, 0, verticalMove);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Entrega = FindObjectOfType<entrega>();
            int tipo = Entrega.devolver();
            Debug.Log("es: "+tipo);
            grab.Play();
            table currentTable = cercaDetection.Getselected();
            if (currentTable != null) {
                holder currentTableHolder = currentTable.GetComponent<holder>();
                if (myPlayerHolder.HasMovable())
                {
                    movableObject movable = myPlayerHolder.GetMovable();
                    Trash trash = currentTable.GetComponent<Trash>();
                    entrega enter = currentTable.GetComponent<entrega>();
                    if (enter != null) {
                        myPlayerHolder.RemoveMovable();
                        PlateTomato.SetActive(false);
                        PlateCebolla.SetActive(false);
                        PlateMushroom.SetActive(false);
                        PlateBad.SetActive(false);
                        empty.SetActive(true);
                        pot Pot = GetComponent<pot>();
                        //GameObject potObject = Pot.full;
                        //GameObject potObject1 = Pot.empty;
                        //potObject.SetActive(false);
                        //potObject1.SetActive(true);
                        segundos = 0;
                        if (marcador == tipo)
                        {
                            puntos += 100;
                            puntaje.text = "" + puntos;
                            marcador = 0;
                            good.Play();
                        } 
                        else
                        {
                            puntos -= 50;
                            puntaje.text = "" + puntos;
                            marcador = 0;
                            bad.Play();
                        }
                    }

                    if (trash != null)
                    {
                        myPlayerHolder.RemoveMovable();
                        Destroy(movable.gameObject);
                        food Food = movable.GetComponent<food>();
                        myPlayerHolder.RemoveMovable();
                        drop.Play();
                    }
                    else {
                        movableObject tableMovable = currentTableHolder.GetMovable();
                        if (tableMovable != null)
                        {
                            drop.Play();
                            Container tableContainer = tableMovable.GetComponent<Container>();
                            if (tableContainer != null) {
                                food FOOD = movable.GetComponent<food>();
                                if (FOOD != null) {
                                    if (tableContainer.CanAccept(FOOD)) {
                                        pot_number += 1;
                                        myPlayerHolder.RemoveMovable();
                                        tableContainer.recived(FOOD);
                                        objeto.SetActive(false);
                                        drop.Play();
                                    }
                                    if (pot_number == 3)
                                    {
                                        objeto_pot.SetActive(true);
                                        //pot_number = pot_number - 3;
                                        foodType r1 = tableContainer.resultado();
                                        foodType r2 = tableContainer.resultado2();
                                        foodType r3 = tableContainer.resultado3();
                                        if (r3 == T && r2 == T && r1 == T)
                                        {
                                            empty.SetActive(false);
                                            PlateTomato.SetActive(true);
                                            marcador = 1;

                                        }
                                        else if (r3 == O && r2 == O && r1 == O)
                                        {
                                            empty.SetActive(false);
                                            PlateCebolla.SetActive(true);
                                            marcador = 0;
                                        }
                                        else if (r3 == M && r2 == M && r1 == M)
                                        {
                                            empty.SetActive(false);
                                            PlateMushroom.SetActive(true);
                                            marcador = 1;
                                        }
                                        else
                                        {
                                            empty.SetActive(false);
                                            PlateBad.SetActive(true);
                                            marcador = 0;
                                        }

                                    }                                    
                                    
                                }
                            }
                        }
                        else {
                            currentTableHolder.SetMovable(movable);
                            myPlayerHolder.RemoveMovable();
                        }
                        
                    }

                }
                else 
                {

                    if (currentTableHolder.HasMovable())
                    {
                        movableObject movable = currentTableHolder.GetMovable();
                        myPlayerHolder.SetMovable(movable);
                        currentTableHolder.RemoveMovable();
                    }
                    else {
                        NewIngrediente ig = currentTable.GetComponent<NewIngrediente>();
                        if (ig != null) {
                            movableObject movable = ig.GetIngredient();
                            myPlayerHolder.SetMovable(movable);
                        }
                    }
                }
            }

        }

        if (pot_number == 3) {
            table currentTable = cercaDetection.Getselected();   
            estufa Estufa = currentTable.GetComponent<estufa>();
            if (Estufa != null){
                segundos = segundos + 0.01f;
                if (segundos > 4)
                {
                    Alarm.Play();
                    humo.SetActive(true);
                    pot_number -= 3;
                    potBurned.SetActive(true);
                }
             }
         }

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            table currentTable = cercaDetection.Getselected();
            if (currentTable != null) {
                chopper currentChopper = currentTable.GetComponent<chopper>();
                if (currentChopper != null) {
                    objeto.SetActive(true);
                    IsChopping = currentChopper.StartChooping();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (moveTo.magnitude > 0.1)
        {
            rb.AddForce(-force * moveTo);
            transform.forward = -force * moveTo;
            chefWalk.SetBool("walk", true);
        }
        else
        {
            chefWalk.SetBool("walk", false);
        }
        
    }

    public void timer()
    {
        targetTime -= Time.deltaTime; ;
        
        tiempoPantala.text = "时间 : " + Mathf.Round(targetTime);
        if (targetTime < 5)
        {
            background.Stop();
            endSound.Play();
        }
        if (targetTime < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +4);
        }

    }
        
    

}
