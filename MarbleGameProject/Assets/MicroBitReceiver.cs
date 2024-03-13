using UnityEngine;
using System.IO.Ports;

public class MicroBitReceiver : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM3", 9600); // Adjust the COM port and baud rate as per your micro:bit configuration

    void Start()
    {
        stream.Open();
        stream.ReadTimeout = 100;
    }

    void Update()
    {
        try
        {
            string data = stream.ReadLine();
            if (data != null)
            {
                // Parse the received data and log it
                string[] parts = data.Split(';');
                string axis = parts[0];
                float value = float.Parse(parts[1]);

                Debug.Log("Received data - Axis: " + axis + ", Value: " + value);

                // Example: Adjust rotation of a GameObject based on received data
                if (axis == "X")
                {
                    transform.Rotate(Vector3.right, value);
                }
                else if (axis == "Y")
                {
                    transform.Rotate(Vector3.up, value);
                }
                else if (axis == "Z")
                {
                    transform.Rotate(Vector3.forward, value);
                }
            }
        }
        catch (System.Exception)
        {
            // Handle exceptions if any
        }
    }

    void OnDestroy()
    {
        stream.Close(); // Close the serial port when the script is destroyed
    }
}
