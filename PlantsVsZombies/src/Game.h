#ifndef GAME_H
#define GAME_H

#include <SFML/Graphics.hpp>
#include <vector>
#include "Plant.h"
#include "Zombie.h"

class Game {
public:
    Game();
    void addPlant(Plant* plant);
    void addZombie(Zombie* zombie);
    void start();

private:
    std::vector<Plant*> plants;
    std::vector<Zombie*> zombies;
    sf::RenderWindow window;
    sf::Texture plantTexture;
    sf::Texture zombieTexture;
};

#endif // GAME_H