using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porus
{
    public partial class PortScanner : Form
    {
        public PortScanner()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        // Initialize DataGridView columns only once
        private void InitializeDataGridView()
        {
            dgvPortScannerGrid.Columns.Clear();
            dgvPortScannerGrid.Columns.Add("Address", "Address");
            dgvPortScannerGrid.Columns.Add("Port", "Port");
            dgvPortScannerGrid.Columns.Add("State", "State");
            dgvPortScannerGrid.Columns.Add("Protocol", "Protocol");
            dgvPortScannerGrid.Columns.Add("ProcessName", "Process Name");
            dgvPortScannerGrid.Columns.Add("ProcessId", "Process ID");
            dgvPortScannerGrid.Columns.Add("RemoteAddress", "Remote Address");
            dgvPortScannerGrid.Columns.Add("RemotePort", "Remote Port");
            //dgvPortScannerGrid.Columns.Add("Duration", "Duration");
            //dgvPortScannerGrid.Columns.Add("GeoLocation", "GeoLocation");
            //dgvPortScannerGrid.Columns.Add("DataSent", "Data Sent");
            //dgvPortScannerGrid.Columns.Add("DataReceived", "Data Received");
            //dgvPortScannerGrid.Columns.Add("ProcessPath", "Process Path");
            //dgvPortScannerGrid.Columns.Add("CommandLine", "Command Line");
            //dgvPortScannerGrid.Columns.Add("FirewallStatus", "Firewall Status");
            dgvPortScannerGrid.Dock = DockStyle.Fill;
            dgvPortScannerGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPortScannerGrid.RowHeadersVisible = false;

            // Add Serial Number column
            var serialNumberColumn = new DataGridViewTextBoxColumn
            {
                Name = "SerialNumber",
                HeaderText = "S.No",
                ReadOnly = true
            };
            dgvPortScannerGrid.Columns.Insert(0, serialNumberColumn);

            // Add Kill Button column
            var killButtonColumn = new DataGridViewButtonColumn
            {
                Name = "KillButton",
                HeaderText = "Kill",
                Text = "Kill",
                UseColumnTextForButtonValue = true
            };
            dgvPortScannerGrid.Columns.Add(killButtonColumn);

            // Handle the CellClick event to detect button clicks
            dgvPortScannerGrid.CellClick += dgvPortScannerGrid_CellClick;
        }

        private async void PortScanner_Load(object sender, EventArgs e)
        {
            LoadPortScannerData();           
        }
       
        private async void LoadPortScannerData()
        {
            try
            {
                // Clear any existing rows in the DataGridView
                dgvPortScannerGrid.Rows.Clear();

                // Get the list of used ports asynchronously
                List<PortInfo> portInfoList = await Task.Run(() => GetPortInfo());

                // Apply Protocol filter
                if (rdoTCPOnly.Checked)
                {
                    portInfoList = portInfoList.Where(p => p.Protocol == "TCP").ToList();
                }
                else if (rdoUDPOnly.Checked)
                {
                    portInfoList = portInfoList.Where(p => p.Protocol == "UDP").ToList();
                }

                // Apply Status filter
                if (rdoEstablished.Checked)
                {
                    portInfoList = portInfoList.Where(p => p.State.Equals("Established", StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else if (rdoListen.Checked)
                {
                    portInfoList = portInfoList.Where(p => p.State.Equals("Listen", StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else if (rdoTimeWait.Checked)
                {
                    portInfoList = portInfoList.Where(p => p.State.Equals("timeWait", StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else if (rdoCloseWait.Checked)
                {
                    portInfoList = portInfoList.Where(p => p.State.Equals("closeWait", StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else if (rdoListening.Checked)
                {
                    portInfoList = portInfoList.Where(p => p.State.Equals("listening", StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // Apply Sorting
                if (rdoSortByPort.Checked)
                {
                    portInfoList = portInfoList.OrderBy(p => p.Port).ToList();
                }
                else if (rdoSortByPID.Checked)
                {
                    portInfoList = portInfoList.OrderBy(p => p.ProcessId).ToList();
                }

                // Bulk insert rows into the DataGridView
                foreach (var portInfo in portInfoList)
                {
                    int rowIndex = dgvPortScannerGrid.Rows.Add();
                    var row = dgvPortScannerGrid.Rows[rowIndex];
                    row.Cells["Address"].Value = portInfo.Address;
                    row.Cells["Port"].Value = portInfo.Port;
                    row.Cells["State"].Value = portInfo.State;
                    row.Cells["Protocol"].Value = portInfo.Protocol;
                    row.Cells["ProcessName"].Value = portInfo.ProcessName;
                    row.Cells["ProcessId"].Value = portInfo.ProcessId;
                    row.Cells["RemoteAddress"].Value = portInfo.RemoteAddress;
                    row.Cells["RemotePort"].Value = portInfo.RemotePort;
                    //row.Cells["Duration"].Value = portInfo.Duration;
                    //row.Cells["GeoLocation"].Value = portInfo.GeoLocation;
                    //row.Cells["DataSent"].Value = portInfo.DataSent;
                    //row.Cells["DataReceived"].Value = portInfo.DataReceived;
                    //row.Cells["ProcessPath"].Value = portInfo.ProcessPath;
                    //row.Cells["CommandLine"].Value = portInfo.CommandLine;
                    //row.Cells["FirewallStatus"].Value = portInfo.FirewallStatus;
                    row.Cells["SerialNumber"].Value = rowIndex + 1; // Serial number
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading port info: {ex.Message}");
            }
        }

        private List<PortInfo> GetPortInfo()
        {
            List<PortInfo> portInfoList = new List<PortInfo>();
            var ipGlobalProps = IPGlobalProperties.GetIPGlobalProperties();

            // Run netstat once and capture all the information
            var netstatOutput = RunNetstat();

            // Get TCP connections
            var tcpConnections = ipGlobalProps.GetActiveTcpConnections();
            foreach (var connection in tcpConnections)
            {
                var processInfo = GetProcessInfoFromNetstat(connection.LocalEndPoint.Port, netstatOutput);
                portInfoList.Add(new PortInfo
                {
                    Address = connection.LocalEndPoint.Address.ToString(),
                    Port = connection.LocalEndPoint.Port,
                    State = connection.State.ToString(),
                    Protocol = "TCP",
                    ProcessName = processInfo.ProcessName,
                    ProcessId = processInfo.ProcessId,
                    RemoteAddress = connection.RemoteEndPoint.Address.ToString(),
                    RemotePort = connection.RemoteEndPoint.Port,
                    //Duration = GetConnectionDuration(connection),  // Assuming method to calculate duration
                    //GeoLocation = GetGeoLocation(connection.RemoteEndPoint.Address.ToString()),  // Get geo-location info
                    // DataSent = GetDataSent(connection.LocalEndPoint.Port),  // Retrieve data sent (if available)
                    // DataReceived = GetDataReceived(connection.LocalEndPoint.Port),  // Retrieve data received (if available)
                    // ProcessPath = GetProcessPath(processInfo.ProcessId),  // Get process path
                    //CommandLine = GetCommandLine(processInfo.ProcessId),  // Get command line
                    //FirewallStatus = GetFirewallStatus(processInfo.ProcessId)  // Check firewall status
                });
            }

            // Get UDP listeners
            var udpListeners = ipGlobalProps.GetActiveUdpListeners();
            foreach (var listener in udpListeners)
            {
                var processInfo = GetProcessInfoFromNetstat(listener.Port, netstatOutput);
                portInfoList.Add(new PortInfo
                {
                    Address = listener.Address.ToString(),
                    Port = listener.Port,
                    State = "LISTENING",  // UDP ports will typically be in the LISTENING state
                    Protocol = "UDP",
                    ProcessName = processInfo.ProcessName,
                    ProcessId = processInfo.ProcessId,
                    // Duration = "N/A",  // No duration for UDP
                    //GeoLocation = "N/A",  // Geo-location not typically available for UDP
                    //DataSent = "N/A",  // No data sent info for UDP
                    // DataReceived = "N/A",  // No data received info for UDP
                    // ProcessPath = GetProcessPath(processInfo.ProcessId),
                    // CommandLine = GetCommandLine(processInfo.ProcessId),
                    //FirewallStatus = GetFirewallStatus(processInfo.ProcessId)
                });
            }

            return portInfoList;
        }

        private string RunNetstat()
        {
            try
            {
                // Initialize the ProcessStartInfo
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C netstat -ano",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Start the process
                using (var process = Process.Start(processStartInfo))
                {
                    // Read the output directly from the process's StandardOutput stream
                    using (var reader = process.StandardOutput)
                    {
                        return reader.ReadToEnd();  // Read all output and return it as a string
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing netstat: {ex.Message}");
                return string.Empty;
            }
        }

        private (string ProcessName, int ProcessId) GetProcessInfoFromNetstat(int port, string netstatOutput)
        {
            string processName = "Unknown";
            int processId = 0;

            // Filter netstat output by the port
            var portLines = netstatOutput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                                          .Where(line => line.Contains($":{port}"))
                                          .ToList();

            if (portLines.Any())
            {
                // Extract the process ID from netstat line
                var parts = portLines.First().Split(' ');
                var pidString = parts.Last(); // Last element is the PID

                if (int.TryParse(pidString, out processId))
                {
                    try
                    {
                        // Try to get process name from the PID
                        var process = Process.GetProcessById(processId);
                        processName = process.ProcessName;
                    }
                    catch
                    {
                        processName = "Unknown";
                    }
                }
            }

            return (processName, processId);
        }

        // Methods to retrieve additional info like duration, geo-location, data sent/received, etc.
        private string GetConnectionDuration(TcpConnectionInformation connection)
        {
            // This is a placeholder for actual duration logic.
            return "N/A";  // Example: Actual connection duration logic
        }

        private string GetGeoLocation(string ipAddress)
        {
            // This is a placeholder for actual geo-location retrieval logic (using an API or database)
            return "N/A";  // Example: Geo-location API call or database lookup
        }

        private string GetDataSent(int port)
        {
            // Placeholder for retrieving data sent
            return "N/A";  // Example: Get data sent for the given port
        }

        private string GetDataReceived(int port)
        {
            // Placeholder for retrieving data received
            return "N/A";  // Example: Get data received for the given port
        }

        private string GetProcessPath(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                return process.MainModule.FileName;
            }
            catch
            {
                return "N/A";
            }
        }

        private string GetCommandLine(int processId)
        {
            try
            {
                var process = Process.GetProcessById(processId);
                return process.StartInfo.Arguments;
            }
            catch
            {
                return "N/A";
            }
        }

        private string GetFirewallStatus(int processId)
        {
            // Placeholder for checking the firewall status
            return "N/A";  // Example: Firewall status check logic
        }

        private void dgvPortScannerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPortScannerGrid.Columns["KillButton"].Index)
            {
                try
                {
                    // Retrieve the Process ID from the selected row
                    int processId = Convert.ToInt32(dgvPortScannerGrid.Rows[e.RowIndex].Cells["ProcessId"].Value);

                    // Confirm the action with the user
                    var result = MessageBox.Show($"Are you sure you want to kill the process with ID {processId}?",
                                                  "Confirm Kill", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Attempt to kill the process
                        var process = Process.GetProcessById(processId);
                        process.Kill();
                        process.WaitForExit(); // Optional: Ensure the process is terminated

                        MessageBox.Show($"Process with ID {processId} has been killed successfully.",
                                        "Process Killed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload data to reflect the changes                
                        LoadPortScannerData();
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("The process no longer exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show($"Failed to kill the process. You may need administrative privileges.\n\n{ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while trying to kill the process.\n\n{ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvPortScannerGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPortScannerGrid.Columns["State"].Index)
            {
                string state = e.Value?.ToString().ToLower();

                if (state == "established".ToLower())
                {
                    e.CellStyle.BackColor = Color.Green;
                }
                else if (state == "listen".ToLower())
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                else if (state == "timeWait".ToLower())
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else if (state == "closeWait".ToLower())
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (state == "listening".ToLower())
                {
                    e.CellStyle.BackColor = Color.MediumPurple;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPortScannerGrid.Columns["Protocol"].Index)
            {
                string state = e.Value?.ToString().ToLower();

                if (state == "TCP".ToLower())
                {
                    e.CellStyle.BackColor = Color.LightBlue;
                }
                else if (state == "UDP".ToLower())
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            InitializeDataGridView();
            LoadPortScannerData();
        }
        private void rdoAllProtocol_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoTCPOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoUDPOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoAllStatus_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoEstablished_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoListen_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoTimeWait_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoCloseWait_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoListening_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoSortByPID_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoSortByPort_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }

        private void rdoExcludeNonIP_CheckedChanged(object sender, EventArgs e)
        {
            LoadPortScannerData();
        }
    }
}
