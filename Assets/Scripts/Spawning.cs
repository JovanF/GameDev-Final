using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    //private GameObject[] branchArray;
    public GameObject branchL;

    //add branchR;

    public GameObject trunk;
    public float leftEdge;
    public float rightEdge;
    public float branchWidth;

    


    // Start is called before the first frame update
    void Start()
    {
        //branchArray = GameObject.FindGameObjectsWithTag("branch");
        //Instantiate(branch, new Vector2(-2, 0), Quaternion.identity);




        getDimensions();

        /*
        float randomOffset1 = Random.Range(-1f, 1f);
        float something1 = (Mathf.Abs(trunkX - branchWidth)) * randomOffset1;
        

        float randomOffset2 = Random.Range(-1f, 1f);
        float something2 = (Mathf.Abs(trunkX - branchWidth)) * randomOffset2;

        float randomOffset3 = Random.Range(-1f, 1f);
        float something3 = (Mathf.Abs(trunkX - branchWidth)) * randomOffset3;


        GameObject branch1 = Instantiate(branch, new Vector2(-3, 0), Quaternion.identity);
        GameObject branch2 = Instantiate(branch, new Vector2(something2, 3), Quaternion.identity);
        GameObject branch3 = Instantiate(branch, new Vector2(something3, 5), Quaternion.identity);

        Debug.Log(branch1.transform.position.x);
        Debug.Log(branch2.transform.position.x);
        Debug.Log(branch3.transform.position.x);


         * all of this is testing.
         * need to make functions for picking and spawning the branches.
         * create if statement for left or right side of trunk (determine what prefab to spawn)
         * create prefab for the middle of the tree (and the if statements for it)
         * */


    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void spawnBranch(float x,float y)
    {
        Instantiate(branchL, new Vector2(0,3), Quaternion.identity);
        Debug.Log(y);
        Debug.Log(x);
        Debug.Log("spawnBranch called.");

    }
    /*
    float pickBranch()
    {
        float offset = Random.Range(-1f, 1f);
        float xValue = (this.transform.position.x - branch.transform.position.x)
        
        Debug.Log("pickBranch called.");
        return

    }
    */

    public void getDimensions()
    {
        SpriteRenderer branchLSprite = branchL.GetComponent<SpriteRenderer>();
        //SpriteRenderer branchRSprite = branchR.GetComponent<SpriteRenderer>();
        SpriteRenderer trunkSprite = this.GetComponent<SpriteRenderer>();

        /*
         float branchWidth = branchSprite.bounds.size.x;
        float trunkWidth = this.GetComponent<SpriteRenderer>().bounds.size.x;
        */

        float branchLWidth = branchLSprite.bounds.extents.x;
        //float branchRWidth;

        leftEdge = trunkSprite.bounds.min.x;
        rightEdge = trunkSprite.bounds.max.x;




    }
}


//make function that takes the values in getdimensions() and does the calculations to find where the branches should spawn in.
//!!!!!!!!!!!!!!!!!
