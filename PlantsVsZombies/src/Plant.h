#ifndef PLANT_H
#define PLANT_H

#include <SFML/Graphics.hpp>

class Plant {
public:
    int health;
    int attackPower;
    sf::Sprite sprite;

    Plant(int h, int ap, sf::Texture& texture);
    void takeDamage(int damage);
    bool isAlive() const;
};

class Sunflower : public Plant {
public:
    Sunflower(sf::Texture& texture);
};

class Peashooter : public Plant {
public:
    Peashooter(sf::Texture& texture);
};

#endif // PLANT_H