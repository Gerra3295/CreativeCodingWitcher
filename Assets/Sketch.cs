using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    public string _WebsiteURL = "http://tetsu3295.azurewebsites.net/tables/Trello3295?zumo-api-version=2.0.0";
   // public string _WebsiteURL = "http://tetsu3295.azurewebsites.net/tables/Trello3295?zumo-api-version=2.0.0";
    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);
        int i = 0;

      //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Trello[] trellos = JsonReader.Deserialize<Trello[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
        Debug.Log(jsonResponse); //added to fix Null bug

        //----------------------
                //We can now loop through the array of objects and access each object individually
        foreach (Trello trello in trellos)
        {
            //Example of how to use the object
            Debug.Log(trello.Title);
            // Debug.Log("This products name is: " + trello.Title);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            int totalCubes = 20; //trellos.Length;

            float totalDistance = 5.0f; //2.9f

                float perc = i / (float)totalCubes;
                float sin = Mathf.Sin(perc * Mathf.PI / 2);

                float x = 3.0f + sin * totalDistance;
                float y = 5.0f;
                float z = 0.0f;

                var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity); //Quaternion is default identity;
                newCube.GetComponent<CubeScript>().SetSize((1.0f - perc)); //(.45f * (1.0f - perc));
                newCube.GetComponent<CubeScript>().RotateSpeed = .1f + perc;
                newCube.GetComponentInChildren<TextMesh>().text = trello.Title;
                newCube.GetComponent<CubeScript>().SetSpinAxis(.1f);
                newCube.GetComponent<Renderer>().material.color = Color.blue;

            i++;
            /* gver771 */
            if (trello.ListName == "Ass2ToDo")
            {
                newCube.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (trello.ListName == "Ass2Doing")
            {
                newCube.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                newCube.GetComponent<Renderer>().material.color = Color.green;
            }
            /* gver771 */
                //----------------------
            }
	}
	    
	// Update is called once per frame
	void Update () {
	
	}
}
