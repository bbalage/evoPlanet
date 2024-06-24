# evoPlanet

## Introduction

The evoPlanet project's GitHub repository can be found [here](https://github.com/bbalage/evoPlanet/).

The project is about creating a web-based orbital simulator, where users can create arbitrary systems of stellar objects and make them move according to the Newtonian rules of gravity.

The created stellar setups can be shared online with other users, and they can also simulate the gravity systems.

---

## Plans

- [ER](/evoPlanet/er)
- [Features](/evoPlanet/features)
- [Frontend](/evoPlanet/frontend)

---

## First Task

Create an end-to-end flow of querying a single planet system! See the image below!

![End-to-End Flow](first_slice.drawio.png)

---

## Workflow

1. **The Angular Component** calls the service (either due to a button push or automatically).
2. **The Angular Service** makes an HTTP request to the backend, sending the name of the planet system it is asking for.
3. **The ASP.NET Controller** receives the request and calls on the C# Service, passing the name of the planet system as an argument.
4. **The C# Service** looks for a JSON file (in a given directory) containing the data of the planet system. It reads the file data and returns it to the Controller.
5. **The Controller** responds with the PlanetSystem's data.
6. **The Angular Service** receives the data and returns it to the Angular Component.
7. **The Component** renders the planet system data on a webpage (a simple text display is sufficient).
