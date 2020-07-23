# Docker  ![Docker Tutorial](https://static.javatpoint.com/docker/images/docker-tutorial.png)
## What is Docker?

Docker is an  **open-source centralized platform designed**  to create, deploy, and run applications. 
Docker uses  **container**  on the host's operating system to run applications.
It allows applications to use the same  **Linux kernel**  as a system on the host computer, rather than creating a whole virtual operating system. 
Containers ensure that our application works in any environment like development, test, or production.
Docker includes components such as  **Docker client, Docker server, Docker machine, Docker hub, Docker composes,**  etc.
### Docker Containers
Docker containers are the  **lightweight**  alternatives of the virtual machine. It allows developers to package up the application with all its libraries and dependencies, and ship it as a single package. The advantage of using a docker container is that you don't need to allocate any RAM and disk space for the applications. It automatically generates storage and space according to the application requirement.
![Docker Introduction ](https://www.javatpoint.com/docker/images/docker-introduction.png)
### Docker architecture

Docker follows Client-Server architecture, which includes the three main components that are  **Docker Client**,  **Docker Host**, and  **Docker Registry**.
[next →](https://www.javatpoint.com/docker-installation)[← prev](https://www.javatpoint.com/docker-features)

# Docker Architecture

Before learning the Docker architecture, first, you should know about the Docker Daemon.

### What is Docker daemon?

Docker daemon runs on the host operating system. It is responsible for running containers to manage docker services. Docker daemon communicates with other daemons. It offers various Docker objects such as images, containers, networking, and storage. s

### Docker architecture

Docker follows Client-Server architecture, which includes the three main components that are  **Docker Client**,  **Docker Host**, and  **Docker Registry**.

![Docker Architecture](https://static.javatpoint.com/docker/images/docker-architecture.png)

### 1. Docker Client

Docker client uses  **commands**  and  **REST APIs**  to communicate with the Docker Daemon (Server). When a client runs any docker command on the docker client terminal, the client terminal sends these docker commands to the Docker daemon. Docker daemon receives these commands from the docker client in the form of command and REST API's request.
Docker Client uses Command Line Interface (CLI) to run the following commands -

docker build

docker pull

docker run
### 2. Docker Host

Docker Host is used to provide an environment to execute and run applications. It contains the docker daemon, images, containers, networks, and storage.

### 3. Docker Registry

Docker Registry manages and stores the Docker images.

There are two types of registries in the Docker -

**Pubic Registry -**  Public Registry is also called as  **Docker hub**.

**Private Registry -**  It is used to share images within the enterprise.
## Docker Objects

There are the following Docker Objects -

### Docker Images

Docker images are the  **read-only binary templates**  used to create Docker Containers.
### Docker Containers

Containers are the structural units of Docker, which is used to hold the entire package that is needed to run the application. The advantage of containers is that it requires very less resources.

In other words, we can say that the image is a template, and the container is a copy of that template.

![Docker Architecture](https://static.javatpoint.com/docker/images/docker-architecture2.png)

### Docker Networking

Using Docker Networking, an isolated package can be communicated. Docker contains the following network drivers -

-   **Bridge -**  Bridge is a default network driver for the container. It is used when multiple docker communicates with the same docker host.
-   **Host -**  It is used when we don't need for network isolation between the container and the host.
-   **None -**  It disables all the networking.
-   **Overlay -**  Overlay offers Swarm services to communicate with each other. It enables containers to run on the different docker host.
-   **Macvlan -**  Macvlan is used when we want to assign MAC addresses to the containers.

### Docker Storage

Docker Storage is used to store data on the container. Docker offers the following options for the Storage -

-   **Data Volume -**  Data Volume provides the ability to create persistence storage. It also allows us to name volumes, list volumes, and containers associates with the volumes.
-   **Directory Mounts -**  It is one of the best options for docker storage. It mounts a host's directory into a container.
-   **Storage Plugins -**  It provides an ability to connect to external storage platforms.

# Install docker on Windows
Follow the below steps to install docker on windows -

**Step 1:**  Click on the below link to download DockerToolbox.exe.  [https://download.docker.com/win/stable/DockerToolbox.exe](https://download.docker.com/win/stable/DockerToolbox.exe)
**Step 2:**  Once the  **DockerToolbox.exe**  file is downloaded,  **double click**  on that file. The following window appears on the screen, in which click on the  **Next**.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows1.png)

**Step 3: Browse the location**  where you want to install the Docker Toolbox and click on the Next.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows2.png)

**Step 4: Select the components**  according to your requirement and click on the  **Next**.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows3.png)

**Step 5: Select Additional Tasks**  and click on the  **Next**.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows4.png)

**Step 6:**  The Docker Toolbox is ready to install. Click on  **Install**.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows5.png)

**Step 7:**  Once the installation is completed, the following Wizard appears on the screen, in which click on the  **Finish**.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows6.png)

**Step 8:**  After the successful installation, three icons will appear on the screen that are:  **Docker Quickstart Terminal, Kitematic (Alpha),**  and  **OracleVM VirtualBox**.  **Double click**  on the Docker Quickstart Terminal.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows7.png)

**Step 9:**  A Docker Quickstart Terminal window appears on the screen.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows8.png)

To verify that the docker is successfully installed, type the below command and press enter key.

1.  docker run hello-world

The following output will be visible on the screen, otherwise not.

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows9.png)

You can check the Docker version using the following command.

1.  docker -version

![install docker on Windows](https://static.javatpoint.com/docker/images/docker-installation-on-windows10.png)
# Docker Container and Image

Docker container is a running instance of an image. You can use Command Line Interface (CLI) commands to run, start, stop, move, or delete a container. You can also provide configuration for the network and environment variables. Docker container is an isolated and secure application platform, but it can share and access to resources running in a different host or container.

An image is a read-only template with instructions for creating a Docker container. A docker image is described in text file called a  **Dockerfile**, which has a simple, well-defined syntax. An image does not have states and never changes. Docker Engine provides the core Docker technology that enables images and containers.
# Docker Dockerfile

A Dockerfile is a text document that contains commands that are used to assemble an image. We can use any command that call on the command line. Docker builds images automatically by reading the instructions from the Dockerfile.

The docker build command is used to build an image from the Dockerfile. You can use the -f flag with docker build to point to a Dockerfile anywhere in your file system.

>``  $ docker build -f /path/to/a/Dockerfile .``
## Dockerfile Instructions
Docker runs instructions of Dockerfile in top to bottom order. The first instruction must be  **FROM**  in order to specify the Base Image.

A statement begin with # treated as a comment. You can use RUN, CMD, FROM, EXPOSE, ENV etc instructions in your Dockerfile.

Here, we are listing some commonly used instructions.

### FROM

This instruction is used to set the Base Image for the subsequent instructions. A valid Dockerfile must have FROM as its first instruction.

``Ex. 1.  FROM ubuntu``

### LABEL

We can add labels to an image to organize images of our project. We need to use LABEL instruction to set label for the image.

``Ex. 1.  LABEL vendorl = "JavaTpoint"``

### RUN

This instruction is used to execute any command of the current image.

Ex. 1.  RUN /bin/bash -c 'source $HOME/.bashrc; echo $HOME'

### CMD

This is used to execute application by the image. We should use CMD always in the following form

``Ex. 1.  CMD ["executable", "param1", "param2"?]``

This is preferred way to use CMD. There can be only one CMD in a Dockerfile. If we use more than one CMD, only last one will execute.

### COPY

This instruction is used to copy new files or directories from source to the filesystem of the container at the destination.

``Ex. 1.  COPY abc/ /xyz``

**Rules**

-   The source path must be inside the context of the build. We cannot COPY ../something /something because the first step of a docker build is to send the context directory (and subdirectories) to the docker daemon.
-   If source is a directory, the entire contents of the directory are copied including filesystem metadata.

### WORKDIR

The WORKDIR is used to set the working directory for any RUN, CMD and COPY instruction that follows it in the Dockerfile. If work directory does not exist, it will be created by default.

We can use WORKDIR multiple times in a Dockerfile.

``Ex. 1.  WORKDIR /var/www/html``

==========
# Docker Push Repository

We can push our Docker image to global repository. It is a public repository provided by Docker officially. It allows us to put our docker image on the server. It is helpful when we want to access our docker image from global. Follow the following steps to push custom image on the Docker hub.

1.  **login to hub.docker.com**

We need to login to our account of Docker hub. If you don't have,  **create it first.**
>`` $ docker login``
2.  **Tag Docker Image**

After login, we need to tag our docker image that we want to push. Following command is used to tag the docker image.

>`` $ docker tag image-name username/image-name``

**username**  refers to our dockerid or the username which is used to login.

**image-name**  is the name of our docker image present on our system.

3.  **Push Docker Image**

The following command is used to push docker image to docker hub repository.

>``  $ docker push username/image-name``
# Docker Useful Commands
### Check Docker version
``$ docker version``

### Build Docker Image from a Dockerfile
``$ docker build -t image-name docker-file-location``
**-t** : it is used to tag Docker image with the provided name.

### Run Docker Image
``$ docker run -d image-name``
**-d**  : It is used to create a daemon process.
### Check available Docker images
``$ docker images``

### Check for latest running container

1.  $ docker ps -l

**-l**  : it is used to show latest available container.

### Check all running containers

1.  $ docker ps -a

**-a**  : It is used to show all available containers.

### Stop running container

``$ docker stop container_id``

**container_id**  : It is an Id assigned by the Docker to the container.

### Delete an image

``$ docker rmi image-name``

### Delete all images

`` $ docker rmi $(docker images -q)``

### Delete all images forcefully

``$ docker rmi -r $(docker images -q)``

**-r**  : It is used to delete image forcefully.

### Delete all containers

``$ docker rm $(docker ps -a -q)``

### Enter into Docker container

`` $ docker exec -it container-id bash``
# Docker Compose

It is a tool which is used to create and start Docker application by using a single command. We can use it to file to configure our application's services.

It is a great tool for development, testing, and staging environments.

It provides the following commands for managing the whole lifecycle of our application.
-   Start, stop and rebuild services
-   View the status of running services
-   Stream the log output of running services
-   Run a one-off command on a service

**To implement compose, it consists the following steps.**

1.  Put Application environment variables inside the Dockerfile to access publicly.
2.  Provide services name in the docker-compose.yml file so they can be run together in an isolated environment.
3.  run docker-compose up and Compose will start and run your entire app.

A typical  **docker-compose.yml**  file has the following format and arguments.

**// docker-compose.yml**
1.  version: '3'
2.  services:
3.  web:
4.  build: .
5.  ports:
6.  - "5000:5000"
7.  volumes:
8.  - .:/code
9.  - logvolume01:/var/log
10.  links:
11.  - redis
12.  redis:
13.  image: redis
14.  volumes:
15.  logvolume01: {}