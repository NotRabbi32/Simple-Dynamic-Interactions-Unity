Simple Dynamic Interactions
======

A Drag and Drop Interaction System to make interacting with the game stupid simple! -
Made for [![Unity](https://img.shields.io/badge/Unity-%23000000.svg?logo=unity&logoColor=white)](#)

### Features
- Makes use of Unity Events for ```OnLookAt```, ```OnLookAway```, ```OnInteractStarted```, ```OnInteractPreformed```, and ```OnInteractCanceled``` for easy assignment in the Inspector
- Adopts [QuickOutline](https://github.com/chrisnolet/QuickOutline) (*made by chrisnolet*) to outline objects when looking at them *- already provided in package*
- Adds a Screen Space UI Tooltip shown above interactables informing players how to interact
- Easy Debug Scene Tool to see Length of Ray if looking at and Interactable

## Install via UPM (*unity package manager*)
1. Open your Unity Project 2022.3 or higher and make your way to the Package Manager

2. In the package Manager go to the plus icon and click ```Install package from git URL...```

3. Copy and Paste this GitURL ```https://github.com/NotRabbi32/Simple-Dynamic-Interactions-Unity.git```

4. Click Install 

And that's it if you want the sample folder to get a demonstration of how it works. In the Package Manager locate the Simple Dynamic Interactions package. Click samples and then click import now a scene will show up in  Project:/Assets/Samples folder inside the Project window.

## How to Use

1. Add ```PlayerInteractor.cs``` to the player
2. Add ```UI Canvas``` Prefab to Scene

3. Set-up ```PlayerInteractor.cs``` components in Inspector
    - Assign Players Camera to ```Interactor Source```
    - Set ```Layer Mask``` to Include Interactable Layers *- bare minimum change from nothing to Default*
    - Set the Child of ```UI Canvas``` the ```InteractionPrompt``` to the ```Prompt``` field
    - Set your ```Interaction Reference``` to your desired InputAction

4. Add ```Interactable.cs``` to any GameObject wt a ```Collider```
5. Set-up ```Interactable.cs```
    - Assign custom public method in ```OnInteractStarted``` event for interaction when the player presses the interact key
    - ```OnInteractPerformed``` is for when u hold down the interact button
    - ```OnInteractCanceled``` is self-explanatory

That's it go into play mode and try to interact now if you have any questions or need help you can find me in the ```#help``` channel in my Discord Server

## Links

[![GitHub](https://img.shields.io/badge/GitHub-%23121011.svg?logo=github&logoColor=white)](https://github.com/NotRabbi32)[![Discord](https://img.shields.io/badge/Discord-%235865F2.svg?&logo=discord&logoColor=white)](https://discord.gg/K5wFNRcjmd)
[![YouTube](https://img.shields.io/badge/YouTube-%23FF0000.svg?logo=YouTube&logoColor=white)](https://www.youtube.com/channel/UCAl0AvFlBxxFjB2WPSWoMFA)
[![Ko-fi](https://img.shields.io/badge/Ko--fi-FF5E5B?logo=ko-fi&logoColor=white)](https://ko-fi.com/rabbi32)
