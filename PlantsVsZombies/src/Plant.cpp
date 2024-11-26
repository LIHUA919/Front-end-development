#include "Plant.h"

Plant::Plant(int h, int ap, sf::Texture& texture) : health(h), attackPower(ap) {
    sprite.setTexture(texture);
}

void Plant::takeDamage(int damage) {
    health -= damage;
}

bool Plant::isAlive() const {
    return health > 0;
}

Sunflower::Sunflower(sf::Texture& texture) : Plant(50, 0, texture) {}

Peashooter::Peashooter(sf::Texture& texture) : Plant(100, 20, texture) {}