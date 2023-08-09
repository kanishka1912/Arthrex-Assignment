# Arthrex-Assignment

**Basic explanation of approach**
As per the given problem statement the program creates particle or so called sphere prefabs in array as per the observed or given image and projects in on top of tracked image using image tracking library in AR foundation also after while projecting once draged over on them to create a bounce back effect.

**Any pre-requisite like package dependencies**
The app was created using Unity 2021.3.18f1 and is compatible for both iOS as well as for Android
Packages Used - ARKit(4.2.8) for iOS, ARCore(4.2.8) for Android, ARFoundation (4.2.7)

**Any other details you want to add to execute your code or run the apk**
The project can be directly build and deployed on Android as well as iOS
The **Pixel Spread** attribute inside **Particle Instantiator** class can be changed based on the device type mostly for iphones 13 and above should be 3 or more and for older gen android devices should be 4 or more.
The code is divided into three major classes
**Particle Instantiater** - To be available on tracked image prefab
**TouchInputHandler** - Drag and drop in scene to raycast on instantiated spheres / particles
**ResetPosition** - To be added on instantiated sphere to create a bounce effect
