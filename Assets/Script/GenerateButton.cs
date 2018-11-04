using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButton : MonoBehaviour {
    ArrayList firstName = new ArrayList();
    string sfirstName;
    ArrayList location = new ArrayList();
    string slocation; 
    ArrayList lastName = new ArrayList();
    string slastName;
    ArrayList period = new ArrayList();
    string speriod;
    ArrayList emotion = new ArrayList();
    string semotion;
    ArrayList personality = new ArrayList();
    string spersonality;
    ArrayList plot = new ArrayList();
    string splot;
    ArrayList hometown = new ArrayList();
    string shometown;
    ArrayList job = new ArrayList();
    string sjob;
    ArrayList country = new ArrayList();
    string scountry;
    ArrayList province = new ArrayList();
    string sprovince;
    XmlReader loader = new XmlReader();



    // Use this for initialization
    void Start () {
        Button btn = this.GetComponent<Button>();
        UiEventListener btnListener = btn.gameObject.AddComponent<UiEventListener>();
        loader.LoadXmlMap();
        int ran;
        btnListener.OnClick += delegate (GameObject gb) {
           
            location = loader.Xmlmap["Location.xml"];
            ran = Random.Range(0, location.Count);
            slocation = location[ran].ToString();

            province = loader.Xmlmap["Province.xml"];
            ran = Random.Range(0, province.Count);
            sprovince = province[ran].ToString();

            //firstName = xmlReader.LoadXml("Firstname");
            //ran = Random.Range(0, firstName.Count);
            //sFirstName = firstName[ran].ToString();

            //lastName = xmlReader.LoadXml("Lastname");
            //ran = Random.Range(0, lastName.Count);
            //sLastName = lastName[ran].ToString();

            //period = xmlReader.LoadXml("Period");
            //ran = Random.Range(0, period.Count);
            //sPeriod = period[ran].ToString();

            //emotion = xmlReader.LoadXml("Emotion");
            //ran = Random.Range(0, emotion.Count);
            //sEmotion = emotion[ran].ToString();

            //personality = xmlReader.LoadXml("Personality");
            //ran = Random.Range(0, personality.Count);
            //sPersonality = personality[ran].ToString();

            //plot = xmlReader.LoadXml("Plot");
            //ran = Random.Range(0, plot.Count);
            //sPlot = plot[ran].ToString();

            //hometown = xmlReader.LoadXml("Hometown");
            //ran = Random.Range(0, hometown.Count);
            //sHometown = hometown[ran].ToString();

            //job = xmlReader.LoadXml("Job");
            //ran = Random.Range(0, job.Count);
            //sJob = job[ran].ToString();

            //country = xmlReader.LoadXml("Country");
            //ran = Random.Range(0, country.Count);
            //sCountry = country[ran].ToString();

            GameObject.Find("StoryText").GetComponent<Text>().text = sprovince;
            //GameObject.Find("StoryText").GetComponent<Text>().text = sFirstName+" "+sLastName+" is a "+sPersonality+" people." + " He comes from "+sHometown+ 
            //", he lives in "+sCountry+" and he is a "+ sJob+" now." + " In his "+sPeriod+" he "+ sPlot +
            //" in "+sLocation+" ." +" he become " + sEmotion +"." ;
            //Debug.Log(sFirstName + " " + sLastName + " is a " + sPersonality + " people." + " He comes from " + sHometown +
            //", he lives in " + sCountry + " and he is a " + sJob + " now." + " In his " + sPeriod + " he " + sPlot +
            //" in " + sLocation + " ." + " he become " + sEmotion + ".");

        };

        //btnListener.OnMouseEnter += delegate (GameObject gb) {
        //    Debug.Log(gb.name + " OnMouseEnter");
        //};

        //btnListener.OnMouseExit += delegate (GameObject gb) {
        //    Debug.Log(gb.name + " OnMOuseExit");
        //};
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
