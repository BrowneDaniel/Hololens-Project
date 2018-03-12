# Hololens-Project
![Build Status](https://brianswhelan.visualstudio.com/_apis/public/build/definitions/52cd2f66-8403-4577-bb9c-342c8f4adf73/1/badge)

[Latest Builds](http://brianw.netsoc.ie/HoloListen-Builds/)
### Install Prerequisites
Tools needed: [here](https://developer.microsoft.com/en-us/windows/mixed-reality/install_the_tools)!
Unity 2017.2.1 required

### Building the Project
Navigate to build settings in Unity and ensure the target platform is set to UWP
Ensure the remaining build settings are as follows:

|Setting Name|Setting Value|
|---|---|
|Target Device|Hololens|
|Build Type|D3D|
|SDK| Latest Installed (16299 currently)|

Then press Build to build the VS Project, or Build & Run to compile the VS Project and run in the emulator/device

To build via Visual Studio:
* Open the Solution
* Set the solution platform to x86
* Set the solution configuration to either Debug, Release or Master
* Build/Debug

### Cognitive Api
* Endpoint: https://api.cognitive.microsoft.com/sts/v1.0

## Creating a feature branch
  * Checkout a new branch with `git checkout -b feat/<feature-name>`
  * Add the local files to staging with `git add .`
  * Commit the files from staging with `git commit -m "<commit-message>"`
  * Push to the remote with `git push origin feat/<feature-name>`
  * A pull request can now be created on GitHub with the new feature.

When finished with the feature branch:
  * Move back to master with `git checkout master`
