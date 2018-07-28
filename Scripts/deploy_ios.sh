#!/bin/bash

# Clean
rm -rf ExportedAssetBundles
rm -rf ExportedBuilds

# Create Directories
mkdir ExportedAssetBundles
mkdir ExportedBuilds

# Increment Minor Version Number
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -logFile -executeMethod BuildPipelineManager.Increment_Version_Minor &&

# Build Asset Bundles for iOS
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -logFile -executeMethod BuildPipelineManager.Build_iOS_AssetBundles &&

# Build Xcode Project
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -logFile -executeMethod BuildPipelineManager.Build_iOS_Game &&

# Build & Deploy
fastlane staging_ios