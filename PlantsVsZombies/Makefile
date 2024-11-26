CXX = g++
CXXFLAGS = -std=c++11 -I/usr/local/include
LDFLAGS = -L/usr/local/lib -lsfml-graphics -lsfml-window -lsfml-system

SRC_DIR = src
OBJ_DIR = obj
BIN_DIR = bin

SOURCES = $(wildcard $(SRC_DIR)/*.cpp)
OBJECTS = $(patsubst $(SRC_DIR)/%.cpp, $(OBJ_DIR)/%.o, $(SOURCES))

TARGET = $(BIN_DIR)/plant_vs_zombie

all: $(TARGET)

$(TARGET): $(OBJECTS)
    $(CXX) $(OBJECTS) -o $(TARGET) $(LDFLAGS)

$(OBJ_DIR)/%.o: $(SRC_DIR)/%.cpp
    $(CXX) $(CXXFLAGS) -c $< -o $@

clean:
    rm -f $(OBJ_DIR)/*.o $(TARGET)
