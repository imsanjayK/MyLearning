# What is Azure IoT Edge
Azure IoT Edge moves cloud analytics and custom business logic to devices so that your organization can focus on business insights instead of data management. Scale out your IoT solution by packaging your business logic into standard containers, then you can deploy those containers to any of your devices and monitor it all from the cloud.
- To respond to emergencies as quickly as possible, you can run anomaly detection workloads at the edge.
- Reduce bandwidth costs and avoid transferring terabytes of raw data, 
- Can clean and aggregate the data locally then only send the insights to the cloud for analysis.

Azure IoT Edge is made up of three components:

-   **IoT Edge modules**  are containers that run Azure services, third-party services, or your own code. Modules are deployed to IoT Edge devices and execute locally on those devices.
-   The  **IoT Edge runtime**  runs on each IoT Edge device and manages the modules deployed to each device.
-   A  **cloud-based interface**  enables you to remotely monitor and manage IoT Edge devices.
## IoT Edge modules[](https://docs.microsoft.com/en-in/azure/iot-edge/about-iot-edge#iot-edge-modules)

IoT Edge modules are units of execution, implemented as Docker compatible containers, that run your business logic at the edge. Multiple modules can be configured to communicate with each other, creating a pipeline of data processing.

Azure IoT Edge supports both Linux and Windows so you can code to the platform of your choice. It supports Java, .NET Core 2.0, Node.js, C, and Python so your developers can code in a language they already know and use existing business logic.

## IoT Edge runtime[](https://docs.microsoft.com/en-in/azure/iot-edge/about-iot-edge#iot-edge-runtime)

The Azure IoT Edge runtime enables custom and cloud logic on IoT Edge devices. The runtime sits on the IoT Edge device, and performs management and communication operations. The runtime performs several functions:

-   Installs and update workloads on the device.
-   Maintains Azure IoT Edge security standards on the device.
-   Ensures that IoT Edge modules are always running.
-   Reports module health to the cloud for remote monitoring.
-   Manages communication between downstream leaf devices and an IoT Edge device, between modules on an IoT Edge device, and between an IoT Edge device and the cloud.
![IoT Edge runtime sends insights and reporting to IoT Hub](https://docs.microsoft.com/en-in/azure/iot-edge/media/about-iot-edge/runtime.png)

The runtime is often used to deploy AI to gateway devices which aggregate and process data from other on-premises devices.
## IoT Edge cloud interface[](https://docs.microsoft.com/en-in/azure/iot-edge/about-iot-edge#iot-edge-cloud-interface)

It's difficult to manage the software life cycle for millions of IoT devices that are often different makes and models or geographically scattered. Workloads are created and configured for a particular type of device, deployed to all of your devices, and monitored to catch any misbehaving devices. These activities can’t be done on a per device basis and must be done at scale.

Azure IoT Edge integrates seamlessly with Azure IoT solution accelerators to provide one control plane for your solution’s needs. Cloud services allow you to:

-   Create and configure a workload to be run on a specific type of device.
-   Send a workload to a set of devices.
-   Monitor workloads running on devices in the field.

![Device telemetry and actions are coordinated with the cloud](https://docs.microsoft.com/en-in/azure/iot-edge/media/about-iot-edge/cloud-interface.png)