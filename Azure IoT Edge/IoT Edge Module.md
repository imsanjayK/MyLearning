# Azure IoT Edge modules
Azure IoT Edge lets you deploy and manage business logic on the edge in the form of _modules_. Azure IoT Edge modules are the smallest unit of computation managed by IoT Edge, and can contain Azure services or solution-specific code.

Consider the four conceptual elements of a module:
-   A  **module image**  is a package containing the software that defines a module.
-   A  **module instance**  is the specific unit of computation running the module image on an IoT Edge device. The module instance is started by the IoT Edge runtime.
-   A  **module identity**  is a piece of information (including security credentials) stored in IoT Hub, that is associated to each module instance.
-   A  **module twin**  is a JSON document stored in IoT Hub, that contains state information for a module instance, including metadata, configurations, and conditions.
## Module images and instances[](https://docs.microsoft.com/en-in/azure/iot-edge/iot-edge-modules#module-images-and-instances)

IoT Edge module images contain applications that take advantage of the management, security, and communication features of the IoT Edge runtime.
The images exist in the cloud and they can be updated, changed, and deployed in different solutions.

Each time a module image is deployed to a device and started by the IoT Edge runtime, a new instance of that module is created. Two devices in different parts of the world could use the same module image.
![Diagram - Module images in cloud, module instances on devices](https://docs.microsoft.com/en-in/azure/iot-edge/media/iot-edge-modules/image_instance.png)
In implementation, modules images exist as container images in a repository, and module instances are containers on devices.
## Module identities[](https://docs.microsoft.com/en-in/azure/iot-edge/iot-edge-modules#module-identities)

When a new module instance is created by the IoT Edge runtime, it gets a corresponding module identity. The module identity is stored in IoT Hub, and is used as the addressing and security scope for all local and cloud communications for that module instance.

The identity associated with a module instance depends on the identity of the device on which the instance is running and the name you provide to that module in your solution.![Diagram - Module identities are unique within devices and across devices](https://docs.microsoft.com/en-in/azure/iot-edge/media/iot-edge-modules/identity.png)
## Module twins[](https://docs.microsoft.com/en-in/azure/iot-edge/iot-edge-modules#module-twins)

Each module instance also has a corresponding module twin that you can use to configure the module instance. The instance and the twin are associated with each other through the module identity.

A module twin is a JSON document that stores module information and configuration properties. This concept parallels the  [device twin](https://docs.microsoft.com/en-in/azure/iot-hub/iot-hub-devguide-device-twins)  concept from IoT Hub. The structure of a module twin is the same as a device twin. The APIs used to interact with both types of twins are also the same. The only difference between the two is the identity used to instantiate the client SDK.