UNITY_BINARY = /Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -quit
PACKAGE_NAME = Bugsnag.unitypackage

EXEC_PATH = $(shell pwd)
BUILD_PATH = $(EXEC_PATH)/build
TEMP_PROJECT_PATH = $(EXEC_PATH)/temp.unityproject

all:
	$(UNITY_BINARY) -createproject $(TEMP_PROJECT_PATH)
	cp -r source/Assets $(TEMP_PROJECT_PATH)
	mkdir -p $(BUILD_PATH)
	$(UNITY_BINARY) -projectpath $(TEMP_PROJECT_PATH) -exportpackage Assets "$(BUILD_PATH)/$(PACKAGE_NAME)"

clean:
	rm -rf $(BUILD_PATH) $(TEMP_PROJECT_PATH)
