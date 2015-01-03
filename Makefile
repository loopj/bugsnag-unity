.PHONY: all clean copy-library example-android

UNITY_BINARY = /Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -quit
PACKAGE_NAME = Bugsnag.unitypackage

EXEC_PATH = $(shell pwd)
BUILD_PATH = $(EXEC_PATH)/build
TEMP_PROJECT_PATH = $(EXEC_PATH)/temp.unityproject
EXAMPLE_PROJECT_PATH = $(EXEC_PATH)/example/HelloWorld

# Build a new Bugsnag.unitypackage
all:
	$(UNITY_BINARY) -createproject $(TEMP_PROJECT_PATH)
	cp -r source/Assets $(TEMP_PROJECT_PATH)
	mkdir -p $(BUILD_PATH)
	$(UNITY_BINARY) -projectpath $(TEMP_PROJECT_PATH) -exportpackage Assets "$(BUILD_PATH)/$(PACKAGE_NAME)"
	rm -r $(TEMP_PROJECT_PATH)

# Remove temporary files
clean:
	rm -rf $(BUILD_PATH) $(TEMP_PROJECT_PATH)
	git clean -f -d -x example

# Copy the Bugsnag plugin files into the example app
copy-library:
	cp -r source/Assets/* $(EXAMPLE_PROJECT_PATH)/Assets

# Build and run the example app on an attached Android device
example-android: copy-library
	$(UNITY_BINARY) -projectpath $(EXAMPLE_PROJECT_PATH) -executeMethod PerformBuild.BuildAndroid
