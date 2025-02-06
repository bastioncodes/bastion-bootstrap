# Bastion for Unity 🏰

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

**Bastion** streamlines Unity app and game development, providing a structured framework that promotes modular architecture, event-driven design, and best practices for scalable projects.

Its goal is to help developers build maintainable and flexible applications by offering clear conventions and a well-organized foundation. Whether you're working on a game, a mobile app, or an interactive experience, Bastion Bootstrap provides the tools to structure your project efficiently—so you can focus on creating great experiences.

This project is part of the vision behind [Bastion Codes](https://bastion.codes), a learning platform dedicated to making software development more accessible, engaging, and structured.

## Installation 📦

Setting up **Bastion Bootstrap** takes just a few minutes! Follow these quick steps to get started.

### 1️⃣ Install [Reflex](https://github.com/gustavopsantos/Reflex)
1. In Unity, open **Window → Package Manager**.
2. Click the **`+`** button and select **"Add package from Git URL"**.
3. Enter the following URL and press **"Add"**:
```
https://github.com/gustavopsantos/reflex.git?path=/Assets/Reflex/#9.0.1
```


### 2️⃣ Install [Newtonsoft Json](https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.2/manual/index.html)
1. In Unity, open **Window → Package Manager**.
2. Click the **`+`** button and select **"Add package from name"**.
3. Enter the package name below and press **"Add"**:

```
com.unity.nuget.newtonsoft-json
```

### 3️⃣ Install [Bastion Bootstrap](https://github.com/bastioncodes/bastion-bootstrap)
1. In Unity, open **Window → Package Manager**.
2. Click the **`+`** button and select **"Add package from Git URL"**.
3. Enter the following URL and press **"Add"**:
```
https://github.com/bastioncodes/bastion-bootstrap.git
```

### 4️⃣ Run the Bastion Installer
1. In Unity, open **Bastion → Install Package** in the top menu bar.
2. This script will automatically set up the core structure of your project:
    - **App.cs** (`Assets/Scripts/App.cs`) → The main entry point of your project.
    - **AppInstaller.cs** (`Assets/Scripts/AppInstaller.cs`) → Handles global dependency injection.
    - **AppConfig.asset** (`Assets/Resources/AppConfig.asset`) → A configuration file for project settings.
3. Once completed, proceed to the next step.

### 5️⃣ Create the App GameObject
1. In Unity, open **GameObject → Bastion → Install App in Scene** in the top menu bar.
2. This will finalize the installation:
   - **App** → A GameObject added to the scene with the **App** script automatically attached.
   - **SceneScope** → A GameObject added to the scene for managing scoped dependencies with the **AppInstaller** script attached.

## Key Features 🚀

Bastion equips you with a robust set of tools, designed to make Unity development as efficient as possible:

| Feature              | Description                                                                                                  |
|----------------------|--------------------------------------------------------------------------------------------------------------|
| Dependency Injection | Powered by Reflex, a lightweight DI framework that is 7x faster than Zenject and 3x faster than VContainer. |
| Serialization   | Utilize Newtonsoft to easily serialize objects, supporting even complex JSON structures right out of the box. |
| File Storage | The built-in FileManager simplifies data storage with intuitive Save/Load functionalities.                   |
| Logging     | Enhance your logging with features like customizable channels, debug modes, and colored logs.                |

## Conventions 📖
| **Class Type** | **Description**                                        | **Main Responsibility**                                         | **Simplified Descriptor**        |
|----------------|--------------------------------------------------------|-----------------------------------------------------------------|----------------------------------|
| **Manager**    | Central interface for module operations.               | Coordinate module operations and interactions.                  | Module Facade                    |
| **Installer**  | Sets up dependencies and configurations for a module.  | Install and initialize all necessary components of a module.    | Initializes Module Components    |
| **Config**     | Configures behavior settings for a specific module.    | Define adjustable parameters for module behavior.               | ScriptableObject                 |
| **Factory**    | Handles creation and initial setup of module components.| Instantiate and configure new component instances with dependencies. | Creates Data Instances          |
| **Spawner**    | Manages in-scene instantiation of module components.   | Spawn component instances within the game environment.          | Instantiates GameObjects         |
| **Repository** | Manages a collection of component data objects.        | Manage and maintain a collection of data objects for access and manipulation. | Manages Data Collection         |
| **Data**       | Stores state and properties of a module component.      | Maintain and serialize state information for components.        | Serializable Class               |
| **Behaviour**  | Manages the combined behavior and presentation of components. | Integrate and manage component interactions, physics, and visual updates. | Manages Component Behaviour     |


## Roadmap 🚧

We're exploring ways to expand Bastion Bootstrap with powerful new features to make development even more efficient. While these ideas represent our vision, their implementation will depend on real-world needs and community interest. Stay tuned as we continue to refine and evolve the framework!

| Feature                   | Description                                                                 |
|---------------------------|-----------------------------------------------------------------------------|
| Caching                   | In-memory and on-disk caching APIs, leveraging Bastion's data structures.   |
| Networking                | Enhance online-offline handling and simplify client-side API communications.|
| Analytics                 | Streamlined Firebase/Google Analytics integration.                          |
| Localization              | Simplified solution for app localization.                                   |
| CI/CD Integration         | Templates and guides for seamless CI/CD setup.                              |
| IAP Integration           | Simplified in-app purchase integration.                                     |
| Native Integrations       | Access to vibration APIs, native modals, and more.                          |
| UI Framework              | Aiming to popularize UI Toolkit with a friendly framework, avoiding prefab clutter.|
| Compliance                | Manage legal terms, like cookie popups, effortlessly.                       |

Bastion is designed to streamline your workflow, helping you focus on building great experiences with less friction. We're continuously improving and evolving it based on real-world needs—stay tuned for more!
