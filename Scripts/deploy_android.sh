#!/bin/bash

# Clean
rm -rf ExportedAssetBundles
rm -rf ExportedBuilds

# Create Directories
mkdir ExportedAssetBundles
mkdir ExportedBuilds

# Increment Minor Version Number
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -logFile -executeMethod BuildPipelineManager.Increment_Version_Minor &&

# Build Asset Bundles for Android
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -logFile -executeMethod BuildPipelineManager.Build_Android_AssetBundles &&

# Build Android APK
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -logFile -executeMethod BuildPipelineManager.Build_Android_Game &&

# Build & Deploy
fastlane staging_android