
# Develop your own IoT Edge modules
## IoT Edge runtime environment[](https://docs.microsoft.com/en-in/azure/iot-edge/module-development#iot-edge-runtime-environment)

The IoT Edge runtime provides the infrastructure to integrate the functionality of multiple IoT Edge modules and to deploy them onto IoT Edge devices. Any program can be packaged as an IoT Edge module. To take full advantage of IoT Edge communication and management functionalities, a program running in a module can use the Azure IoT Device SDK to connect to the local IoT Edge hub.
## Using the IoT Edge hub[](https://docs.microsoft.com/en-in/azure/iot-edge/module-development#using-the-iot-edge-hub)

The IoT Edge hub provides two main functionalities: proxy to IoT Hub, and local communications.

### IoT Hub primitives[](https://docs.microsoft.com/en-in/azure/iot-edge/module-development#iot-hub-primitives)

IoT Hub sees a module instance analogously to a device, in the sense that:

-   it has a module twin that is distinct and isolated from the  [device twin](https://docs.microsoft.com/en-in/azure/iot-hub/iot-hub-devguide-device-twins)  and the other module twins of that device;
-   it can send  [device-to-cloud messages](https://docs.microsoft.com/en-in/azure/iot-hub/iot-hub-devguide-messaging);
-   it can receive  [direct methods](https://docs.microsoft.com/en-in/azure/iot-hub/iot-hub-devguide-direct-methods)  targeted specifically at its identity.

When writing a module, you can use the [Azure IoT Device SDK](https://docs.microsoft.com/en-in/azure/iot-hub/iot-hub-devguide-sdks) to connect to the IoT Edge hub and use the above functionality as you would when using IoT Hub with a device application. The only difference between IoT Edge modules and IoT device applications is that you have to refer to the module identity instead of the device identity.
### Device-to-cloud messages[](https://docs.microsoft.com/en-in/azure/iot-edge/module-development#device-to-cloud-messages)

To enable complex processing of device-to-cloud messages, IoT Edge hub provides declarative routing of messages between modules, and between modules and IoT Hub. Declarative routing allows modules to intercept and process messages sent by other modules and propagate them into complex pipelines.
An IoT Edge module, as opposed to a normal IoT Hub device application, can receive device-to-cloud messages that are being proxied by its local IoT Edge hub to process them.
To simplify the creation of routes, IoT Edge adds the concept of module _input_ and _output_ endpoints. A module can receive all device-to-cloud messages routed to it without specifying any input, and can send device-to-cloud messages without specifying any output.

Finally, device-to-cloud messages handled by the Edge hub are stamped with the following system properties:
|Property             | Description        |
|---------------------|--------------------|
| $connectionDeviceId |The device ID of the client that sent the message
| $connectionModuleId |The module ID of the module that sent the message
| $inputName          |The input that received this message. Can be empty.
| $outputName         |The output used to send the message. Can be empty.

### Connecting to IoT Edge hub from a module[](https://docs.microsoft.com/en-in/azure/iot-edge/module-development#connecting-to-iot-edge-hub-from-a-module)
Connecting to the local IoT Edge hub from a module involves two steps:
1.  Create a ModuleClient instance in your application.
2.  Make sure your application accepts the certificate presented by the IoT Edge hub on that device.

Create a ModuleClient instance to connect your module to the IoT Edge hub running on the device, similar to how DeviceClient instances connect IoT devices to IoT Hub.

# Development and test environment for IoT Edge
In any IoT Edge solution, there are at least two machines to consider. One is the IoT Edge device (or devices) itself, which runs the IoT Edge module. The other is the development machine that you use to build, test, and deploy modules. This article focuses primarily on the development machine. For testing purposes, the two machines can be the same. You can run IoT Edge on your development machine and deploy modules to it.
In any IoT Edge solution, there are at least two machines to consider. One is the IoT Edge device (or devices) itself, which runs the IoT Edge module. The other is the development machine that you use to build, test, and deploy modules.
## Operating system[](https://docs.microsoft.com/en-in/azure/iot-edge/development-environment#operating-system)
For developing for IoT Edge, you can use most operating systems that can run a container engine. The container engine is a requirement on the development machine to build your modules as containers and push them to a container registry.
## Container engine
The central concept of IoT Edge is that you can remotely deploy your business and cloud logic to devices by packaging it into containers. To build containers, you need a container engine on your development machine.
The only supported container engine for IoT Edge devices in production is Moby.
## Development tools[](https://docs.microsoft.com/en-in/azure/iot-edge/development-environment#development-tools)
The Azure IoT Edge extensions for Visual Studio and Visual Studio Code help you code, build, deploy, and debug your IoT Edge solutions.
With the extensions, you can also manage your IoT devices from within Visual Studio or Visual Studio Code. Deploy modules to a device, monitor the status, and view messages as they arrive at IoT Hub. Both extensions use the [IoT EdgeHub dev tool](https://docs.microsoft.com/en-in/azure/iot-edge/development-environment#iot-edgehub-dev-tool) to enable local running and debugging of modules on your development machine as well.
### IoT Edge dev tool[](https://docs.microsoft.com/en-in/azure/iot-edge/development-environment#iot-edge-dev-tool)

The Azure IoT Edge dev tool simplifies IoT Edge development with command-line abilities. This tool provides CLI commands to develop, debug, and test modules. The IoT Edge dev tool works with your development system, whether you've manually installed the dependencies on your machine or are using the IoT Edge dev container.

