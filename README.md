## UGemini

A C# wrapper for the Google Gemini API.

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
        - *`com.utilities`
4. Open the Unity Package Manager window (`Window` -> `Package Manager`)
5. Change the registry from `Unity` to `My Registries`
6. Add the `UGemini` and *`Utilities.Encoder.Wav` packages

#### From GitHub Through Unity Package Manager

1. Open the Unity Package Manager window (`Window` -> `Package Manager`)
2. Select the `+` icon and `Add package from git URL...`
3. Paste the UPM branch URL and press enter:
    - `https://github.com/Uralstech/UGemini.git#upm`

*\*Adding additional dependencies:*<br/>
Follow the steps detailed in the OpenUPM installation method and only install the *`Utilities.Encoder.Wav` package.

*Optional, but required if you don't want to bother with encoding your AudioClips into Base64 strings manually.

### Gemini API Support

- [x] `models` endpoint :warning:
    - [ ] `batchEmbedContents` method
    - [x] `countTokens` method
    - [ ] `embedContent` method
    - [ ] `generateAnswer` method :test_tube:
    - [x] `generateContent` method
        - [x] JSON output :test_tube:
        - [x] System instructions :test_tube:
        - [x] Text generation
        - [x] Vision
        - [x] Function calling :test_tube:
        - [x] Safety settings

    - [ ] `get` method
    - [ ] `list` method
    - [ ] `streamGenerateContent` method
    
- [ ] `cachedContents` endpoint :test_tube:
- [ ] `corpora` endpoint :test_tube:
- [ ] `files` endpoint :test_tube:
- [ ] `media` endpoint :test_tube:
- [ ] `tunedModels` endpoint
- [ ] `operations` endpoint

:warning: - Not all methods/features of supported

:test_tube: - Using the v1beta API

### Documentation

See <https://github.com/Uralstech/UGemini/blob/master/UGemini/Packages/com.uralstech.ugemini/Documentation~/README.md>.
