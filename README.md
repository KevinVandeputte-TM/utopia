# Utopia 2.0
Welcome to Utopia 2.0! In this repository you can find the source code of team 'Weboos' for the Proof of Concept. We present you with a new and innovative way of letting students discover the educative programs within Thomas More. Click [here](https://utopia-utopiasite-kevinvandeputte-tm.cloud.okteto.net/) to start playing the game!

![Utopia](https://user-images.githubusercontent.com/74854941/212747487-a3783889-fae9-4cdf-b17f-36f2a3429990.png)

Utopia is represented as an underground network, in which the stations each represent an education. The individual lines can be seen as a collection of educations that follow the same kind of interest.

![Metro](https://user-images.githubusercontent.com/74854941/212755668-511688ca-6d7e-4c9a-8a33-e5dd3e1bfc0e.png)

Utopia is comprised of three main programs:
- The game itself is made in the Unity game engine.
- A microservices back-end takes care of all the data storage and processing.
- A web application that hosts the game and allows some extra functionality for analytics and gathering feedback.

## Unity
Utopia 2.0 is made in the Unity game engine as a WebGL project. This platform allows the programmer to use lots of features and packages that help in creating a game, which normal web development platforms do not offer. We used a template for Isometric 2D development. More info on this template can be found [here](https://blog.unity.com/technology/isometric-2d-environments-with-tilemap).

### Installation
To load the game, you will need to install Unity Hub first. The download files can be found [here](https://unity.com/download). From within Unity Hub, you can intall the right version of Unity to run the application. Utopia is made in version `2021.3.14f1`. Visit the Unity [Download Archive](https://unity.com/releases/editor/archive) and download the correct version through Unity Hub. After the install is complete, you can safely run Utopia and explore the game.

### Important directories
All editing of the game happens within the `Assets` folder. In there, you can find the following directories:
- Art

This folder contains all art that is used in the game, from animations, sprites (custom game objects) and tiles to create the world.

- Audio

Contains all audio used in the game.

- Fonts

All fonts used in the game are stored here.

- Prefabs

A prefab is used as a template for commonly used game objects that need similar layout and functionality. This can go from a simple menu button to a whole environment. Changing the prefab will change all game objects that implemented it.

- Scenes

A unity game is comprised of different scenes that are linked to each other. Every scene is a separate page in which the user can explore and interact with the game.

- Scripts

All functionality and logic is stored in C# scripts. These allow the programmer to fully control the behaviour of the game objects in the scene. Scripts are also used to interact with the micro-services backend that was built to support the game. This means collecting and also writing data to the database.

### Useful links
A handful of tutorials were followed to get to know the Unity game engine. Below you can find some useful links that can help you get on your way with Unity.

- [Ruby's Adventure](https://learn.unity.com/project/ruby-s-2d-rpg)
  - This tutorial is ideal for building experience in Unity for Isometric 2D development. Basic concepts are shown while building this game, leaving you with an overall understanding of the platform after you've finished it.
- Other


## Back-end
For documentation of the back-end we refer to the `edge-service`, where all information about the microservice architecture is gathered. Information on the different services used, how to run the services locally and ways of testing are mentioned there.

Click [here](https://github.com/KevinVandeputte-TM/utopia_edgeservice) to consult the Edge Service repository.

## Web application
A Java web application built in the Spring Boot framework is used to host the game. The repository can be found [here](https://github.com/ValerieBecquart/project4website). The Unity project is built in a WebGL format, which allows us to run it on a web page using an iframe. 

Besides hosting the game, the web application can also gather feedback from the user after playing the game. Different aspects of the game can be judged in a feedback form, and also a general score can be given.

Lastly, the game gathers information about the user interactions while playing. This information is displayed using graphs made in Qlik sense. The graphs are loaded on a separate page `/analyse` using iframes. Data shown here can be useful to generate insights in the popularity of each education.
