# Bastion for Unity 🏰

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

**Bastion** streamlines Unity app and game development, packing a lightweight DI framework and essential tools into one powerful package.

## Key Features ✨

Bastion equips you with a robust set of tools, designed to make Unity development as efficient as possible:

| Feature              | Description                                                                                                  |
|----------------------|--------------------------------------------------------------------------------------------------------------|
| Dependency Injection | Powered by Reflex, a lightweight DI framework that is 7x faster than Zenject and 3x faster than VContainer. |
| Serialization   | Utilize Newtonsoft to easily serialize objects, supporting even complex JSON structures right out of the box. |
| File Storage | The built-in FileManager simplifies data storage with intuitive Save/Load functionalities.                   |
| Logging     | Enhance your logging with features like customizable channels, debug modes, and colored logs.                |

## Conventions
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

Coming soon. Probably. Maybe. Perhaps. Never.

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

Bastion is all about efficiency and simplicity, giving you the power to focus on what matters most—creating amazing experiences. Stay tuned as we continue to expand Bastion's capabilities!
