using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    //GameObjects
    public GameObject branchL;
    public GameObject branchC;
    public GameObject branchR;
    public GameObject trunk;

    public float branchDelay = 1f;


    //Position variables
    public float leftEdge;
    public float centerPoint;
    public float rightEdge;
    public float branchWidth;
    public float LeftValue;
    public float RightValue;


    // Start is called before the first frame update
    void Start()
    {

        getDimensions();
        StartCoroutine(BranchSpawning());

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    //Get dimensions of the prefabs and calculates the significant points
    public void getDimensions()
    {
        SpriteRenderer branchLSprite = branchL.GetComponent<SpriteRenderer>();
        //SpriteRenderer branchRSprite = branchR.GetComponent<SpriteRenderer>();
        SpriteRenderer trunkSprite = this.GetComponent<SpriteRenderer>();
        branchWidth = branchLSprite.bounds.extents.x;
        leftEdge = trunkSprite.bounds.min.x;
        centerPoint = trunkSprite.transform.position.x;
        rightEdge = trunkSprite.bounds.max.x;
        LeftValue = leftEdge - branchWidth;
        RightValue = rightEdge + branchWidth;

    }



    // Determines where the branches will get spawned.
    public float randomDecision()
    {
        // Adjust the weights based on your preference
        //lower weight = less chance to be spawned
        float weightLeft = 1f;
        float weightCenter = 0.6f;
        float weightRight = 1f;

        // Calculate the total weight
        float totalWeight = weightLeft + weightCenter + weightRight;

        // Generate a random value within the total weight
        float randomValue = Random.Range(0f, totalWeight);
        Debug.Log(randomValue);

        // Determine the selected branch based on weights
        if (randomValue < weightLeft)
        {
            return LeftValue;
        }
        else if (randomValue < weightLeft + weightCenter)
        {
            return centerPoint;
        }
        else
        {
            return RightValue;
        }
    }

    //Creates the branches in spot picked.
    public void Creator(GameObject branch, float position)
    {
        Instantiate(branch, new Vector2(position, 6), Quaternion.identity);
    }

    // Determines how often branches get picked / spawned.
    IEnumerator BranchSpawning()
    {
        while (true)
        {
            float branchPosition = 0;
            float randomValue = randomDecision();

            GameObject branchPicked = null;

            if (randomValue == centerPoint)
            {
                branchPicked = branchC;
                branchPosition = centerPoint;
            }
            else if (randomValue == LeftValue)
            {
                branchPicked = branchL;
                branchPosition = LeftValue;
            }
            else if (randomValue == RightValue)
            {
                branchPicked = branchR;
                branchPosition = RightValue;
            }

            // Create branch
            Creator(branchPicked, branchPosition);

            // Wait for x seconds before the next iteration
            yield return new WaitForSeconds(branchDelay);
        }
    }



    /* Old code
    
    //Determines where the branches will get spawned.
    public float randomDecision()
    {
        float decision = Mathf.RoundToInt(Random.Range(1f, 4f));
        

        if (decision == 1)
        {
            decision = LeftValue;
        }
        else if (decision == 3)
            {
                decision = RightValue;
        }
        else
        {
            decision = centerPoint;
        }


        return decision;
    }

    //Determines how often branches get picked / spawned.
    IEnumerator BranchSpawning()
    {
        while (true)
        {

            float branchPosition = 0;
            // Call GetRandomValue and get the return value
            float randomValue = randomDecision();

            GameObject branchPicked = null;


            if (randomValue == centerPoint)
            {
                branchPicked = branchC;
                branchPosition = centerPoint;
            }
            
            else if (randomValue == LeftValue)
            {
                branchPicked = branchL;
                branchPosition = LeftValue;
            }
            else if (randomValue == RightValue)
            {
                branchPicked = branchR;
                branchPosition = RightValue;
            }

            //create branch
            Creator(branchPicked, branchPosition);


            // Wait for x seconds before the next iteration
            yield return new WaitForSeconds(branchDelay);
        }

    }
    */
}