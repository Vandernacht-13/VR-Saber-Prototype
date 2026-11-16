
# VR Saber Prototype — Part 1

### Immersive Rhythm-Based VR Game

A virtual reality rhythm game developed using **Unity 6, C# and the XR Interaction Toolkit (XRI)** for the **Meta Quest 2**.

This project was developed for our assesment for the Virtual, Augmented and Spatial Computing module at Technological University of the Shannon (TUS).

## Project Overview

VR Saber Prototype: recreating an interaction from a VR game of our choice. In this instance, a cube-slice interaction.

Inspired by *Beat Saber*, players use two motion-tracked virtual sabers to strike approaching cubes.

The project explores Human–Computer Interaction (HCI), immersive design and the integration of visual, auditory and haptic feedback.

## Features

- **Dual-controller interaction:** Virtual sabers respond to the player's physical hand movements.
- **Moving targets:** Cubes spawn and travel towards the player.
- **Audio feedback:** Background music and impact sounds accompany gameplay.
- **Haptic feedback:** Controller vibration reinforces successful strikes.
- **Score tracking:** Each successful strike awards 10 points.


## Technologies Used

- Unity 6
- C#
- XR Interaction Toolkit
- OpenXR
- Meta Quest 2
- TextMeshPro
- Unity Particle System
- Unity Physics

## Controls

| Action | Control |
|---|---|
| Move left saber | Left Quest controller |
| Move right saber | Right Quest controller |
| Strike cubes | Swing either saber into an approaching cube |

## Installation and Setup

### Requirements

- Unity 6 with Android Build Support
- XR Interaction Toolkit and OpenXR
- Meta Quest 2 headset
- USB-C connection for headset deployment

### Running the Project

1. Clone or download this repository.
2. Open Unity Hub.
3. Select **Add project from disk** and locate the downloaded project folder.
4. Open the project using a compatible Unity 6 Editor.
5. Open the `SaberGame_MovingCubes` scene from the Assets/Scenes folder.
6. Ensure the Android build target and XR settings are configured for Meta Quest.
7. Connect the headset and deploy the application using Unity's Build and Run functionality.

## Evaluation and Testing

The application was developed through iterative testing in the Unity Editor and directly on the Meta Quest 2.

Testing focused on:

- Controller tracking and collision detection
- Cube spawning and movement
- Visual, audio and haptic feedback
- Android build performance

Development challenges included resolving audio playback problems on the headset, cube elements spawning, and disappearing.

The completed application was successfully tested on the Meta Quest 2. Evaluation was tested with external participants.

## Future Improvements

Potential future developments include:

- More accurate synchronisation between cube spawning and musical beats
- Particle effects when cube is struck
- Results scoreboard
- Combination and scoreboard tracker
- Further evaluation with external participants

## Author

Harper Alexander

Creative Digital Computing  
Technological University of the Shannon (TUS)

## Project Status

**Completed — Part 1, November 2026**

The Unity source files are included in this repository. The Android APK, demonstration video, project report and evaluation evidence are provided separately as part of the university assessment submission.
