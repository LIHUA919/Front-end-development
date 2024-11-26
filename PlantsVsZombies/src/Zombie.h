#ifndef ZOMBIE_H
#define ZOMBIE_H

#include <SFML/Graphics.hpp>

class Zombie {
public:
    int health;
    int attackPower;
    sf::Sprite sprite;

    Zombie(int h, int ap, sf::Texture& texture);
    void takeDamage(int damage);
    bool isAlive() const;
};

class BasicZombie : public Zombie {
public:
    BasicZombie(sf::Texture& texture);
};

class ConeheadZombie : public Zombie {
public:
    ConeheadZombie(sf::Texture& texture);
};

#endif // ZOMBIE_H