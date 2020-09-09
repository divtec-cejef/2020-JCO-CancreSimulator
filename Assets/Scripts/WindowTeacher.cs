using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTeacher : MonoBehaviour
{
    // Position d'arrivée
    [SerializeField] private Vector3 target = new Vector3(-8.4f, -1.1f, 0);
    // Position de départ
    [SerializeField] private Vector3 start = new Vector3(-11.8f, -1.1f, 0);
    //nouvelle position
    [SerializeField] private Vector3 targetProgress;

    //Vitesse de déplacement
    [SerializeField] private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        moveOUT();
    }

    // Update is called once per frame
    void Update()
    {
        //Fait entrer le prof
        if (transform.position.x < targetProgress.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }
        //Fait sortir le prof
        if (transform.position.x > targetProgress.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, start, Time.deltaTime * speed);
        }
    }

    /**
     *  Fait bouger le prof dans la salle
     */
    public void moveIN()
    {
        targetProgress = transform.position + new Vector3(3.4f, 0, 0);
        print(targetProgress);
    }

    /**
     * Fait bouger le prof hors de la salle
     */
    public void moveOUT()
    {
        targetProgress = transform.position - new Vector3(3.4f, 0, 0);
        print(targetProgress);
    }

    /**
     * Tant que le prof n'est pas à sa position d'arrivée, il n'est pas considéré comme "dans la classe"
     */
    public bool isTeacherIN()
    {
        return (transform.position == target);
    }
}
