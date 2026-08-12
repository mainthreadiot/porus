# Porus Utility

**Porus Utility** is a free and open-source Windows desktop tool built in C# for IoT developers, test engineers, and network administrators. It brings essential communication, diagnostics, encoding, and monitoring utilities into one workspace.

Developed by **Thread IoT**  
Contact: **main.thread.iot@gmail.com**

## Download

- Website: [mainthreadiot.github.io/porus](https://mainthreadiot.github.io/porus/)

## Overview

Porus Utility is designed to simplify day-to-day engineering tasks such as network testing, port validation, protocol communication, telemetry inspection, firmware workflows, and barcode or QR generation. It combines multiple bench and support tools into a single desktop application with a consistent operator-focused interface.

![Porus Dashboard](https://github.com/user-attachments/assets/4491b209-f78f-450c-863d-f04406729604)

## Key Features

### Network Diagnostics

- **Port Scanner**
  Scan active ports and inspect connection details such as address, port, protocol, process name, process ID, remote address, and remote port.

- **Port Checker**
  Check whether a specific port is open or closed on a target host.

- **TCP Client and TCP Server**
  Test point-to-point TCP communication for development, troubleshooting, and validation.

- **UDP Client and UDP Server**
  Send and monitor UDP traffic for low-overhead transport testing.

- **TCP Socket Utility**
  Work with raw socket communication for custom test scenarios.

### IoT Communication

- **MQTT Client**
  Publish and subscribe to MQTT topics with a streamlined workflow for broker testing and device telemetry validation.

- **Serial Communication**
  Open and use COM ports for embedded and device-level communication.

- **Serial Terminal Lab**
  Inspect serial traffic with decoding-oriented bench workflows.

- **Live Variable Dashboard**
  Ingest JSON telemetry and flatten nested values into a live monitoring table.

- **Live Plotting Dashboard**
  Visualize incoming telemetry in real time for bench and diagnostics use cases.

- **Firmware Upgrade Lab**
  Support firmware package and transfer workflows for IoT-oriented testing.

### Data and Utility Tools

- **Checksum Calculator**
  Generate and validate checksums using:
  - `Simple Checksum`
  - `CRC32`
  - `MD5`
  - `SHA256`

- **Barcode Generator and Decoder**
  Create `CODE_128` barcodes from text and decode barcode images back into text.

- **QR Code Generator and Decoder**
  Generate QR codes from text and decode QR images back into readable content.

- **Base64 Conversion**
  Convert image or payload content into Base64 when needed for integration or debugging workflows.

### Advanced Lab Features

- **BLE Explorer**
  Browse BLE devices and inspect GATT-oriented information.

- **Macro Automation Lab**
  Build repeatable bench-side validation flows.

## Screenshots

### Port Checker
![Port Checker](https://github.com/user-attachments/assets/c91cd5f4-90b3-4f80-b50f-33bfb80bde32)

### Checksum Calculator
![Checksum Calculator](https://github.com/user-attachments/assets/68018af0-14c4-4c6c-9ebd-3589d80f6ad2)

### MQTT Utility
![MQTT Utility](https://github.com/user-attachments/assets/61d74a11-d9c7-45ba-8be5-1792ba1b6a48)

### TCP Server and Client
![TCP Utility](https://github.com/user-attachments/assets/e1f9af43-2784-4e8b-be9c-fdb3ecaceefc)

### UDP Server and Client
![UDP Utility](https://github.com/user-attachments/assets/559ac0d6-70ad-4619-836e-20fcc932cb92)

### Barcode Conversion
![Barcode Conversion](https://github.com/user-attachments/assets/2b662aa2-317b-416a-8203-60fda09f2354)

### QR Code Conversion
![QR Code Conversion](https://github.com/user-attachments/assets/8e2370f1-221a-4ceb-96ca-98e6d6e9f73a)

### Serial Communication
![Serial Communication](https://github.com/user-attachments/assets/e18a4767-612d-4a21-bef6-c7c70f5a0066)

## Built With

- **C#**
- **.NET Framework WinForms**
- **MQTTnet**
- **ZXing.Net**
- **Newtonsoft.Json**

## Use Cases

- IoT device bring-up
- MQTT broker testing
- TCP and UDP protocol validation
- Serial communication debugging
- Port inspection and diagnostics
- Telemetry monitoring
- Checksum and payload verification
- Barcode and QR generation for production or support workflows

## Roadmap

Planned and upcoming areas include:

- `FTP / SFTP`
- `Firewall Checker`
- `Packet Sniffer`
- `JSON Formatter`
- `Modbus Support`
- `SMTP and SMS Tester`

## Getting Started

### Run the Application

1. Clone this repository.
2. Open `Thread.MQTT.sln` in Visual Studio.
3. Restore NuGet packages if prompted.
4. Build and run the project.

### Requirements

- Windows
- Visual Studio with .NET desktop development tools
- .NET Framework support required by the solution

## Project Status

Porus Utility is actively evolving with new operator-focused tools for IoT communication, diagnostics, and test workflows.

## Contributing

Contributions, suggestions, and issue reports are welcome. If you would like to improve the tool, feel free to open an issue or submit a pull request.

## License

Add your preferred license here, for example `MIT`, if you plan to distribute the project as open source.
