using F1GameTelemetry;
using System.Net;

// Use this app to test that the basic UdpListening is working as intended

new UdpListener(IPAddress.Any, 20777);
Console.WriteLine("Hello World!");
Console.ReadLine();