using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;

namespace Porus
{
    public class PortInfo
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public string State { get; set; }
        public string Protocol { get; set; }  // TCP or UDP
        public string ProcessName { get; set; }
        public int ProcessId { get; set; }
        public string RemoteAddress { get; set; } // Only for TCP
        public int RemotePort { get; set; }       // Only for TCP
       
        public string Duration { get; set; }
        public string GeoLocation { get; set; }
        public string DataSent { get; set; }

        public string DataReceived { get; set; }
        public string ProcessPath { get; set; }
        public string CommandLine { get; set; }
        public string FirewallStatus { get; set; }
        public override string ToString()
        {
            string remoteInfo = Protocol == "TCP" ? $" Remote Address: {RemoteAddress}:{RemotePort}" : "";
            return $"{Address}:{Port} - State: {State} - Protocol: {Protocol} - Process: {ProcessName} (PID: {ProcessId}){remoteInfo}";
        }
    }

    public class PortScannerClass
    {
        public static List<PortInfo> GetUsedPorts()
        {
            List<PortInfo> portInfoList = new List<PortInfo>();
            var ipGlobalProps = IPGlobalProperties.GetIPGlobalProperties();

            // Get TCP connections
            var tcpConnections = ipGlobalProps.GetActiveTcpConnections();
            foreach (var connection in tcpConnections)
            {
                var processInfo = GetProcessInfoByPort(connection.LocalEndPoint.Port);
                portInfoList.Add(new PortInfo
                {
                    Address = connection.LocalEndPoint.Address.ToString(),
                    Port = connection.LocalEndPoint.Port,
                    State = connection.State.ToString(),
                    Protocol = "TCP",
                    ProcessName = processInfo.ProcessName,
                    ProcessId = processInfo.ProcessId,
                    RemoteAddress = connection.RemoteEndPoint.Address.ToString(),
                    RemotePort = connection.RemoteEndPoint.Port
                });
            }

            // Get UDP listeners
            var udpListeners = ipGlobalProps.GetActiveUdpListeners();
            foreach (var listener in udpListeners)
            {
                var processInfo = GetProcessInfoByPort(listener.Port);
                portInfoList.Add(new PortInfo
                {
                    Address = listener.Address.ToString(),
                    Port = listener.Port,
                    State = "LISTENING",  // UDP ports will typically be in the LISTENING state
                    Protocol = "UDP",
                    ProcessName = processInfo.ProcessName,
                    ProcessId = processInfo.ProcessId
                });
            }

             return portInfoList;
        }

        private static (string ProcessName, int ProcessId) GetProcessInfoByPort(int port)
        {
            string processName = "Unknown";
            int processId = 0;

            try
            {
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    var startInfo = process.StartInfo;
                    var command = $"netstat -ano | findstr :{port}";
                    var netstatProcess = Process.Start(new ProcessStartInfo("cmd.exe", $"/C {command}") { RedirectStandardOutput = true, UseShellExecute = false });
                    var output = netstatProcess.StandardOutput.ReadToEnd();

                    if (!string.IsNullOrEmpty(output))
                    {
                        var pidString = output.Split(' ').Last();  // Get PID from netstat output
                        processId = int.Parse(pidString);
                        processName = process.ProcessName;
                        break;
                    }
                }
            }
            catch
            {
                // Handle error if necessary
            }

            return (processName, processId);
        }
    }
}
