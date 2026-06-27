using UnityEngine.UI;
using UnityEngine;

public class LavaCollision : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;


    bool Cylinder1Knocked = false;
    bool Cylinder2Knocked = false;
    bool Cylinder3Knocked = false;

    public GameManager GM;

    void Update()
    {

    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Cylinder1")
        {
            Cylinder1Knocked = true;
            Debug.Log("Cylinder 1 Down!");
            text1.enabled = false;
        }

        if (collisionInfo.collider.tag == "Cylinder2")
        {
            Cylinder2Knocked = true;
            Debug.Log("Cylinder 2 Down!");
            text2.enabled = false;
        }

        if (collisionInfo.collider.tag == "Cylinder3")
        {
            Cylinder3Knocked = true;
            Debug.Log("Cylinder 3 Down!");
            text3.enabled = false;
        }



        bool AllCylindersKnocked = (Cylinder1Knocked && Cylinder2Knocked && Cylinder3Knocked);

        if (AllCylindersKnocked)
        {
            GM.CompleteLevel();
        }
    }

}