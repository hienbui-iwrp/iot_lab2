using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lab2
{
    public class UIManager : MonoBehaviour
    {
        // public static UIManager instance;
        public InputField brokerURI;
        public InputField username;
        public InputField password;
        public Text temp;
        public Text humi;
        public Button led;
        public Button pump;

        public GameObject layer1;
        public GameObject layer2;

        bool ledStatus = false;
        bool pumpStatus = true; 

        void Start()
        {
            layer1.SetActive(true);
            layer2.SetActive(false);
            brokerURI.text = "mqttserver.tk";
            username.text = "bkiot";
            password.text = "12345678";
        }

        public void updateStatus(string temp, string humi)
        {
            this.temp.text = temp + "°C";
            this.humi.text = humi + "%";
        }

        public void login()
        {
            layer2.SetActive(true);
            layer1.SetActive(false);
        }

        public void logout()
        {
            layer1.SetActive(true);
            layer2.SetActive(false);
        }

        public void changeLed()
        {

            GetComponent<ManagerMqtt>().PublishConfigLed(!ledStatus);
            led.interactable = false;
        }

        public void setLed(bool on)
        {
            led.interactable = true;
            if (on)
            {
                led.gameObject.GetComponent<Image>().color = new Color32(116,169,50,255);
                led.gameObject.transform.GetChild(0).GetComponent<Text>().text = "ON";
                ledStatus = true;
            }
            else
            {
                led.gameObject.GetComponent<Image>().color = new Color32(169,79,50,255);
                led.gameObject.transform.GetChild(0).GetComponent<Text>().text = "OFF";
                ledStatus = false;
            }
        }

        public void changePump()
        {
            GetComponent<ManagerMqtt>().PublishConfigPump(!pumpStatus);
            pump.interactable = false;
        }

        public void setPump(bool on)
        {
            pump.interactable = true;
            if (on)
            {
                pump.gameObject.GetComponent<Image>().color = new Color32(116,169,50,255);
                pump.gameObject.transform.GetChild(0).GetComponent<Text>().text = "ON";
                pumpStatus = true;
            }
            else
            {
                pump.gameObject.GetComponent<Image>().color = new Color32(169,79,50,255);
                pump.gameObject.transform.GetChild(0).GetComponent<Text>().text = "OFF";
                pumpStatus = false;
            }

        }
    }
    
}