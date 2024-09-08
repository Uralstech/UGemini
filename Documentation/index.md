---
_layout: landing
---

# UGemini

A Unity C# wrapper for the Google Gemini API.

[![openupm](https://img.shields.io/npm/v/com.uralstech.ugemini?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.uralstech.ugemini/)
[![openupm](https://img.shields.io/badge/dynamic/json?color=brightgreen&label=downloads&query=%24.downloads&suffix=%2Fmonth&url=https%3A%2F%2Fpackage.openupm.com%2Fdownloads%2Fpoint%2Flast-month%2Fcom.uralstech.ugemini)](https://openupm.com/packages/com.uralstech.ugemini/)

## Installation

This *should* work on any reasonably modern Unity version. Built and tested in Unity 2022.3.29f1.

# [OpenUPM](#tab/openupm)

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

# [Unity Package Manager](#tab/upm)

1. Open the Unity Package Manager window (`Window` -> `Package Manager`)
2. Select the `+` icon and `Add package from git URL...`
3. Paste the UPM branch URL and press enter:
    - `https://github.com/Uralstech/UGemini.git#upm`

*Adding additional dependencies:*<br/>
See the installation steps for the [Utilities.Async](https://github.com/rageAgainstThePixel/com.utilities.async)\* and [Utilities.Encoder.Wav](https://github.com/rageAgainstThePixel/com.utilities.encoder.wav)\* packages.

# [GitHub Clone](#tab/github)

1. Clone or download the repository from the desired branch (master, preview/unstable)
2. Drag the package folder `UGemini/UGemini/Packages/com.uralstech.ugemini` into your Unity project's `Packages` folder
3. In the `Packages` folder of your project, add the following line to the list in `manifest.json`:
    `"com.uralstech.ugemini": "2.x.x",`

*Adding additional dependencies:*<br/>
See the installation steps for the [Utilities.Async](https://github.com/rageAgainstThePixel/com.utilities.async)\* and [Utilities.Encoder.Wav](https://github.com/rageAgainstThePixel/com.utilities.encoder.wav)\* packages.

---

*Optional, but `Utilities.Async` is required for streaming content and `Utilities.Encoder.Wav` is recommended if you don't want to bother with encoding your AudioClips into Base64 strings manually.

## Preview Versions

Do not use preview versions (i.e. versions that end with "-preview") for production use as they are unstable and untested.

## Gemini API Support

- ✔️ `models` endpoint
    - ✔️ `batchEmbedContents` method
    - ✔️ `countTokens` method
    - ✔️ `embedContent` method
    - ✔️ `generateAnswer` method 🧪
    - ✔️ `generateContent` method
    - ✔️ `get` method
    - ✔️ `list` method
    - ✔️ `streamGenerateContent` method
    
- ✔️ `cachedContents` endpoint 🧪
    - ✔️ `create` method
    - ✔️ `delete` method
    - ✔️ `get` method
    - ✔️ `list` method
    - ✔️ `patch` method

- ❌ `corpora` endpoint 🧪
- ✔️ `files` endpoint 🧪
    - ✔️ `delete` method
    - ✔️ `get` method
    - ✔️ `list` method

- ✔️ `media` endpoint 🧪
    - ✔️ `upload` method
    
- ✔️ `tunedModels` endpoint (Unstable)
    - ✔️ `create` method
    - ✔️ `delete` method
    - ✔️ `generateContent` method
    - ✔️ `get` method
    - ✔️ `list` method
    - ✔️ `patch` method
    - ✔️ `transferOwnership` method

- ✔️ `tunedModels.operations` endpoint\*
    - ✔️ `cancel` method
    - ✔️ `get` method
    - ✔️ `list` method
    
- ✔️ `operations` endpoint\*
    - ✔️ `delete` method
    - ✔️ `list` method

🧪 - Using the v1beta API

\*Through package dependency [UCloud.Operations](https://github.com/Uralstech/UCloud.Operations).

## Documentation

See <https://uralstech.github.io/UGemini/DocSource/QuickStart.html> or `APIReferenceManual.pdf` and `Documentation.pdf` in the package documentation for the reference manual and tutorial.