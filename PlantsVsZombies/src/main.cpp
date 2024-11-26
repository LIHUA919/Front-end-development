#include "Game.h"

int main() {
    Game game;

    // Add some plants
    game.addPlant(new Sunflower(game.plantTexture));
    game.addPlant(new Peashooter(game.plantTexture));

    // Add some zombies
    game.addZombie(new BasicZombie(game.zombieTexture));
    game.addZombie(new ConeheadZombie(game.zombieTexture));

    // Start the game
    game.start();

    return 0;
}