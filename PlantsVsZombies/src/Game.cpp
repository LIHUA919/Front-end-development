#include "Game.h"
#include <iostream>
#include <ctime>
#include <cstdlib>

Game::Game() : window(sf::VideoMode(800, 600), "Plant vs Zombie") {
    if (!plantTexture.loadFromFile("res/plant.png")) {
        std::cerr << "Failed to load plant texture" << std::endl;
    }
    if (!zombieTexture.loadFromFile("res/zombie.png")) {
        std::cerr << "Failed to load zombie texture" << std::endl;
    }
}

void Game::addPlant(Plant* plant) {
    plants.push_back(plant);
}

void Game::addZombie(Zombie* zombie) {
    zombies.push_back(zombie);
}

void Game::start() {
    srand(time(0));
    while (window.isOpen()) {
        sf::Event event;
        while (window.pollEvent(event)) {
            if (event.type == sf::Event::Closed)
                window.close();
        }

        window.clear();

        for (auto& plant : plants) {
            window.draw(plant->sprite);
        }

        for (auto& zombie : zombies) {
            window.draw(zombie->sprite);
        }

        window.display();

        if (!plants.empty() && !zombies.empty()) {
            int plantIndex = rand() % plants.size();
            int zombieIndex = rand() % zombies.size();

            plants[plantIndex]->takeDamage(zombies[zombieIndex]->attackPower);
            zombies[zombieIndex]->takeDamage(plants[plantIndex]->attackPower);

            if (!plants[plantIndex]->isAlive()) {
                delete plants[plantIndex];
                plants.erase(plants.begin() + plantIndex);
            }

            if (!zombies[zombieIndex]->isAlive()) {
                delete zombies[zombieIndex];
                zombies.erase(zombies.begin() + zombieIndex);
            }
        }

        if (plants.empty()) {
            std::cout << "Zombies win!" << std::endl;
            window.close();
        } else if (zombies.empty()) {
            std::cout << "Plants win!" << std::endl;
            window.close();
        }
    }
}