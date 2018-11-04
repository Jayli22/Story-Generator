using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button btn = this.GetComponent<Button>();
        UiEventListener btnListener = btn.gameObject.AddComponent<UiEventListener>();

        btnListener.OnClick += delegate (GameObject gb) {
            string locationInput = GameObject.Find("LocationInput").GetComponent<InputField>().text;
            string firstnameInput = GameObject.Find("FirstnameInput").GetComponent<InputField>().text;

            string lastnameInput = GameObject.Find("LastnameInput").GetComponent<InputField>().text;
            string plotInput = GameObject.Find("PlotInput").GetComponent<InputField>().text;
            string emotionInput = GameObject.Find("EmotionInput").GetComponent<InputField>().text;
            string personalityInput = GameObject.Find("PersonalityInput").GetComponent<InputField>().text;
            string periodInput = GameObject.Find("PeriodInput").GetComponent<InputField>().text;




            if (locationInput!=" "&&locationInput!="")
            {
                XmlReader xmlReader = new XmlReader();
                xmlReader.addXMLData("Location", locationInput);
            }
            if (firstnameInput != " " && firstnameInput != "")
            {
                XmlReader xmlReader = new XmlReader();
                xmlReader.addXMLData("Firstname", firstnameInput);
            }
            if (lastnameInput != " " && lastnameInput != "")
            {
                XmlReader xmlReader = new XmlReader();
                xmlReader.addXMLData("Lastname", lastnameInput);
            }
            if (plotInput != " " && plotInput != "")
            {
                XmlReader xmlReader = new XmlReader();
                xmlReader.addXMLData("Plot", plotInput);
            }
            if (emotionInput != " " && emotionInput != "")
            {
                XmlReader xmlReader = new XmlReader();
                xmlReader.addXMLData("Emotion", emotionInput);
            }
            if (personalityInput != " " && personalityInput != "")
            {
                XmlReader xmlReader = new XmlReader();
                xmlReader.addXMLData("Personality", personalityInput);
            }
            if (periodInput != " " && periodInput != "")
            {
                XmlReader xmlReader = new XmlReader();
                xmlReader.addXMLData("Period", periodInput);
            }



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
