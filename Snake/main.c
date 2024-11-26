// main.c
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <time.h>
#include "snake.h"

int main() {
    Game game;
    
    // 初始化随机种子
    srand(time(NULL));

    // 隐藏控制台光标
    CONSOLE_CURSOR_INFO cursor_info = {1, 0};
    SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &cursor_info);

    // 初始化游戏
    init_game(&game);

    // 游戏主循环
    while (!game.game_over) {
        // 处理输入
        input_handler(&game);

        // 移动蛇
        move_snake(&game);

        // 检查碰撞
        if (check_collision(&game)) {
            game.game_over = 1;
        }

        // 绘制地图
        draw_map(&game);

        // 控制游戏速度
        Sleep(200);
    }

    // 游戏结束显示分数
    printf("Game Over! Final Score: %d\n", game.score);

    return 0;
}