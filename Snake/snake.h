// snake.h
#ifndef SNAKE_H
#define SNAKE_H

#define MAX_LENGTH 100
#define MAP_WIDTH 30
#define MAP_HEIGHT 20

typedef struct {
    int x;
    int y;
} Point;

typedef struct {
    Point body[MAX_LENGTH];
    int length;
    int direction; // 0-上, 1-下, 2-左, 3-右
} Snake;

// 游戏状态结构体
typedef struct {
    Snake snake;
    Point food;
    int score;
    int game_over;
} Game;

// 函数声明
void init_game(Game *game);
void draw_map(Game *game);
void input_handler(Game *game);
void move_snake(Game *game);
void generate_food(Game *game);
int check_collision(Game *game);

#endif