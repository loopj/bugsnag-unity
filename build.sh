#!/bin/bash

UNITY=/Applications/Unity/Unity.app/Contents/MacOS/Unity
EXEC_PATH=`pwd`
TEMP_UNITY_PATH="$EXEC_PATH/temp.unityproject"
BUILD_PATH="$EXEC_PATH/build"

# Clean up
rm -rf $TEMP_UNITY_PATH
rm -rf $BUILD_PATH

echo "Creating new, empty unity3d project"
${UNITY} -batchmode -quit -createproject $TEMP_UNITY_PATH
if [ $? -ne 0 ]; then
  echo "Error! Exiting"
  exit 1
fi

echo "Copying required files into new project"
cp -r source/Assets $TEMP_UNITY_PATH

echo "Exporting unitypackage from temporary unity3d project"
mkdir -p $BUILD_PATH
${UNITY} -batchmode -quit -projectpath "$TEMP_UNITY_PATH" -exportpackage Assets "$BUILD_PATH/Bugsnag.unitypackage"
if [ $? -ne 0 ]; then
  echo "Error! Exiting"
  exit 1
fi

echo "Cleaning up"
rm -rf $TEMP_UNITY_PATH
