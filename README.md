## UGemini

A Unity C# wrapper for the Google Gemini API.

[![openupm](https://img.shields.io/npm/v/com.uralstech.ugemini?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.uralstech.ugemini/)
[![openupm](https://img.shields.io/badge/dynamic/json?color=brightgreen&label=downloads&query=%24.downloads&suffix=%2Fmonth&url=https%3A%2F%2Fpackage.openupm.com%2Fdownloads%2Fpoint%2Flast-month%2Fcom.uralstech.ugemini)](https://openupm.com/packages/com.uralstech.ugemini/)

### Installation

This *should* work on any reasonably modern Unity version. Built and tested in Unity 2022.3.29f1.

#### From OpenUPM Through Unity Package Manager

1. Open project settings
2. Select `Package Manager`
3. Add the OpenUPM package registry:
    - Name: `OpenUPM`
    - URL: `https://package.openupm.com`
    - Scope(s)
        - `com.uralstech`
        - `com.utilities`*
4. Open the Unity Package Manager window (`Window` -> `Package Manager`)
5. Change the registry from `Unity` to `My Registries`
6. Add the `UGemini`, `Utilities.Async`* and `Utilities.Encoder.Wav`* packages

#### From GitHub Through Unity Package Manager

1. Open the Unity Package Manager window (`Window` -> `Package Manager`)
2. Select the `+` icon and `Add package from git URL...`
3. Paste the UPM branch URL and press enter:
    - `https://github.com/Uralstech/UGemini.git#upm`

*Adding additional dependencies:*<br/>
Follow the steps detailed in the OpenUPM installation method and only install the `Utilities.Async`* and `Utilities.Encoder.Wav`* packages.

#### From GitHub Clone/Download

1. Clone or download the repository from the desired branch (master, preview/unstable)
2. Drag the package folder `UGemini/UGemini/Packages/com.uralstech.ugemini` into your Unity project's `Packages` folder
3. In the `Packages` folder of your project, add the following line to the list in `manifest.json`:
    `"com.uralstech.ugemini": "2.x.x",`

*Adding additional dependencies:*<br/>
Follow the steps detailed in the OpenUPM installation method and only install the `Utilities.Async`* and `Utilities.Encoder.Wav`* packages.

*Optional, but `Utilities.Async` is required for streaming content and `Utilities.Encoder.Wav` is recommended if you don't want to bother with encoding your AudioClips into Base64 strings manually.

### Gemini API Support

- [x] `models` endpoint
    - [x] `batchEmbedContents` method
    - [x] `countTokens` method
    - [x] `embedContent` method
    - [x] `generateAnswer` method 🧪
    - [x] `generateContent` method ⚠️
    - [x] `get` method
    - [x] `list` method
    - [x] `streamGenerateContent` method
    
- [ ] `cachedContents` endpoint 🧪
- [ ] `corpora` endpoint 🧪
- [x] `files` endpoint 🧪
    - [x] `delete` method
    - [x] `get` method
    - [x] `list` method

- [x] `media` endpoint 🧪
    - [x] `upload` method
    
- [x] `tunedModels` endpoint ⚠️
    - [x] `generateContent` method

⚠️ - Not all methods/features are supported<br/>
🚧 - The feature is being worked on and is unstable<br/>
🧪 - Using the v1beta API

### Documentation

See <https://uralstech.github.io/UGemini/> or `refman.pdf` in the package documentation for reference manual w/ tutorial.