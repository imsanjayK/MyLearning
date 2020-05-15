# Deploy your first IoT Edge module to a virtual Windows device

Learn how to:
1.  Create an IoT hub.
2.  Register an IoT Edge device to your IoT hub.
3.  Install and start the IoT Edge runtime on your virtual device.
4.  Remotely deploy a module to an IoT Edge device and send telemetry to IoT Hub.
![Diagram - Quickstart architecture for device and cloud](https://docs.microsoft.com/en-in/azure/iot-edge/media/quickstart/install-edge-full.png)

## Install and start the IoT Edge runtime[](https://docs.microsoft.com/en-in/azure/iot-edge/quickstart#install-and-start-the-iot-edge-runtime)
Install the Azure IoT Edge runtime on your IoT Edge device and configure it with a device connection string. 
The IoT Edge runtime is deployed on all IoT Edge devices. It has three components. 
- The **IoT Edge security daemon** starts each time an IoT Edge device boots and bootstraps the device by starting the IoT Edge agent. 
- The **IoT Edge agent** manages deployment and monitoring of modules on the IoT Edge device, including the IoT Edge hub. 
- The **IoT Edge hub** handles communications between modules on the IoT Edge device, and between the device and IoT Hub.

The installation script also includes a container engine called Moby that manages the container images on your IoT Edge device.
### Install and configure the IoT Edge service[](https://docs.microsoft.com/en-in/azure/iot-edge/quickstart#install-and-configure-the-iot-edge-service)

Use PowerShell to download and install the IoT Edge runtime.
1. In the virtual machine, run PowerShell as an administrator. Use an AMD64 session of PowerShell to install IoT Edge, not PowerShell (x86).
```ps1
(Get-Process -Id $PID).StartInfo.EnvironmentVariables["PROCESSOR_ARCHITECTURE"]
```
2. The **Deploy-IoTEdge** command checks that your Windows machine is on a supported version, turns on the containers feature, downloads the Moby runtime, and then downloads the IoT Edge runtime.
```ps1
. {Invoke-WebRequest -useb aka.ms/iotedge-win} | Invoke-Expression; ` Deploy-IoTEdge -ContainerOs Windows
```
3. The  **Initialize-IoTEdge**  command configures the IoT Edge runtime on your machine. The command defaults to manual provisioning with Windows containers.
```ps1
. {Invoke-WebRequest -useb aka.ms/iotedge-win} | Invoke-Expression; `
Initialize-IoTEdge -ContainerOs Windows
```
4. When prompted for a **DeviceConnectionString**, provide the string.
### View the IoT Edge runtime status[](https://docs.microsoft.com/en-in/azure/iot-edge/quickstart#view-the-iot-edge-runtime-status)
Verify that the runtime was successfully installed and configured.
1.  Check the status of the IoT Edge service.
	```ps1
	Get-Service iotedge
	```
2. If you need to troubleshoot the service, retrieve the service logs.
	```ps1
	. {Invoke-WebRequest -useb aka.ms/iotedge-win} | Invoke-Expression; Get-IoTEdgeLog
	```
3. View all the modules running on your IoT Edge device. Since the service just started for the first time, you should only see the **edgeAgent** module running. The edgeAgent module runs by default and helps to install and start any additional modules.
	```ps1
	iotedge list
	 ```  
	 It's ready to run cloud-deployed modules.
## Deploy a module[](https://docs.microsoft.com/en-in/azure/iot-edge/quickstart#deploy-a-module)

Manage your Azure IoT Edge device from the cloud to deploy a module that sends telemetry data to IoT Hub.
One of the key capabilities of Azure IoT Edge is being able to deploy code to your IoT Edge devices from the cloud.
 **IoT Edge modules** are executable packages implemented as containers.
 
 To deploy your first module from the Azure Marketplace, use the following steps:
 1.  Click on the device ID of the target device from the list of devices.
    
2.  On the upper bar, select  **Set Modules**.
    
3.  In the  **IoT Edge Modules**  section of the page, click  **Add**.
    
4.  From the drop-down menu, select  **Marketplace Module**.
   
    ![Simulated Temperature Sensor in Azure portal search](https://docs.microsoft.com/en-in/azure/includes/media/iot-edge-deploy-module/search-for-temperature-sensor.png)
5. In the **IoT Edge Module Marketplace**, search for "Simulated Temperature Sensor" and select that module. Select  **Next: Routes**  to continue to the next step of the wizard.
6. On the **Routes** tab of the wizard, you define how messages are passed between modules and the IoT Hub. Messages are constructed using name/value pairs. Select **Next: Review + create** to continue to the next step of the wizard.
7. On the **Review + create** tab of the wizard, you can preview the JSON file that defines all the modules that get deployed to your IoT Edge device. Select **Create** when you're done reviewing.

## View generated data[](https://docs.microsoft.com/en-in/azure/iot-edge/quickstart#view-generated-data)
In this case, the module that you pushed creates sample data that you can use for testing. The simulated temperature sensor module generates environment data that you can use for testing later. The simulated sensor is monitoring both a machine and the environment around the machine. For example, this sensor might be in a server room, on a factory floor, or on a wind turbine. The message includes ambient temperature and humidity, machine temperature and pressure, and a timestamp.

View the messages being sent from the temperature sensor module to the cloud.
```ps1
iotedge logs SimulatedTemperatureSensor -f
```
>**NOTE:**  IoT Edge commands are case-sensitive when referring to module names.