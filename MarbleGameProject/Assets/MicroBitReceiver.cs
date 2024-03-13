using UnityEngine;
using System.IO.Ports;

[RequireComponent(typeof(SerialDecoder))] // Reference to SerialDecoder
public class MicroBitReceiver : MonoBehaviour
{
    public string receivedTransmission;
    private SerialDecoder decoder; // Reference to SerialDecoder

    private void Awake()
    {
        decoder = GetComponent<SerialDecoder>(); // Reference to SerialDecoder
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log(msg);
        receivedTransmission = msg;
        ParseString(msg);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }

    public void ParseString(string input)
    {
        decoder.Parse(input); // Call Parse method of SerialDecoder
    }

    [ContextMenu("Parse")]
    public void TestString()
    {
        ParseString(receivedTransmission);
    }
}
