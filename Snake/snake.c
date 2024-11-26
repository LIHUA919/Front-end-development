// snake.c
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <conio.h>
#include <windows.h>
#include "snake.h"

void init_game(Game *game) {
    // 初始化蛇的位置和长度
    game->snake.length = 3;
    game->snake.direction = 3; // 初始向右移动
    game->score = 0;
    game->game_over = 0;

    // 初始蛇身位置
    for (int i = 0; i < game->snake.length; i++) {
        game->snake.body[i].x = 10 - i;
        game->snake.body[i].y = 10;
    }

    // 生成食物
    generate_food(game);
}

void draw_map(Game *game) {
    // 清屏
    system("cls");

    // 绘制地图边界
    for (int i = 0; i < MAP_WIDTH + 2; i++) {
        printf("=");
    }
    printf("\n");

    // 绘制游戏区域
    for (int y = 0; y < MAP_HEIGHT; y++) {
        printf("|");
        for (int x = 0; x < MAP_WIDTH; x++) {
            int is_snake = 0;
            int is_food = 0;

            // 检查是否是蛇身
            for (int i = 0; i < game->snake.length; i++) {
                if (game->snake.body[i].x == x && game->snake.body[i].y == y) {
                    is_snake = 1;
                    break;
                }
            }

            // 检查是否是食物
            if (game->food.x == x && game->food.y == y) {
                is_food = 1;
            }

            // 绘制相应的字符
            if (is_snake) {
                printf("O");
            } else if (is_food) {
                printf("*");
            } else {
                printf(" ");
            }
        }
        printf("|\n");
    }

    // 绘制下边界
    for (int i = 0; i < MAP_WIDTH + 2; i++) {
        printf("=");
    }
    printf("\n");

    // 显示分数
    printf("Score: %d\n", game->score);
}

void generate_food(Game *game) {
    int x, y;
    int is_valid;

    do {
        is_valid = 1;
        x = rand() % MAP_WIDTH;
        y = rand() % MAP_HEIGHT;

        // 检查食物是否与蛇身重叠
        for (int i = 0; i < game->snake.length; i++) {
            if (game->snake.body[i].x == x && game->snake.body[i].y == y) {
                is_valid = 0;
                break;
            }
        }
    } while (!is_valid);

    game->food.x = x;
    game->food.y = y;
}

void input_handler(Game *game) {
    if (_kbhit()) {
        char key = _getch();
        switch (key) {
            case 'w':
                if (game->snake.direction != 1) game->snake.direction = 0;
                break;
            case 's':
                if (game->snake.direction != 0) game->snake.direction = 1;
                break;
            case 'a':
                if (game->snake.direction != 3) game->snake.direction = 2;
                break;
            case 'd':
                if (game->snake.direction != 2) game->snake.direction = 3;
                break;
            case 'q':
                game->game_over = 1;
                break;
        }
    }
}

void move_snake(Game *game) {
    // 移动蛇身
    for (int i = game->snake.length - 1; i > 0; i--) {
        game->snake.body[i] = game->snake.body[i - 1];
    }

    // 根据方向移动蛇头
    switch (game->snake.direction) {
        case 0: // 上
            game->snake.body[0].y--;
            break;
        case 1: // 下
            game->snake.body[0].y++;
            break;
        case 2: // 左
            game->snake.body[0].x--;
            break;
        case 3: // 右
            game->snake.body[0].x++;
            break;
    }

    // 检查是否吃到食物
    if (game->snake.body[0].x == game->food.x && 
        game->snake.body[0].y == game->food.y) {
        game->score++;
        game->snake.length++;
        generate_food(game);
    }
}

int check_collision(Game *game) {
    Point head = game->snake.body[0];

    // 检查是否撞墙
    if (head.x < 0 || head.x >= MAP_WIDTH || 
        head.y < 0 || head.y >= MAP_HEIGHT) {
        return 1;
    }

    // 检查是否撞到自己
    for (int i = 1; i < game->snake.length; i++) {
        if (head.x == game->snake.body[i].x && 
            head.y == game->snake.body[i].y) {
            return 1;
        }
    }

    return 0;
}