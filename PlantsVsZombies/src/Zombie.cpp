#include "Zombie.h"

Zombie::Zombie(int h, int ap, sf::Texture& texture) : health(h), attackPower(ap) {
    sprite.setTexture(texture);
}

void Zombie::takeDamage(int damage) {
    health -= damage;
}

bool Zombie::isAlive() const {
    return health > 0;
}

BasicZombie::BasicZombie(sf::Texture& texture) : Zombie(120, 10, texture) {}

ConeheadZombie::ConeheadZombie(sf::Texture& texture) : Zombie(150, 15, texture) {}