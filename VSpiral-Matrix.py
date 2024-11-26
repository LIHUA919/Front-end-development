import matplotlib.pyplot as plt
from typing import List


def spiralOrder(matrix: List[List[int]]) -> List[int]:
    result = []
    if not matrix:
        return result

    left, right = 0, len(matrix[0]) - 1
    top, bottom = 0, len(matrix) - 1

    while left <= right and top <= bottom:
        # Traverse from left to right
        for i in range(left, right + 1):
            result.append(matrix[top][i])
        top += 1

        # Traverse from top to bottom
        for i in range(top, bottom + 1):
            result.append(matrix[i][right])
        right -= 1

        if top <= bottom:
            # Traverse from right to left
            for i in range(right, left - 1, -1):
                result.append(matrix[bottom][i])
            bottom -= 1

        if left <= right:
            # Traverse from bottom to top
            for i in range(bottom, top - 1, -1):
                result.append(matrix[i][left])
            left += 1

    return result


# 示例矩阵
matrix_example = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
]

# 执行螺旋遍历获取结果
spiral_result = spiralOrder(matrix_example)

# 可视化部分
fig, ax = plt.subplots()

# 绘制矩阵每个元素的位置（这里简单用数字表示位置）
for i in range(len(matrix_example)):
    for j in range(len(matrix_example[0])):
        ax.text(j, i, f"{i},{j}", ha='center', va='center', color='black')

# 绘制螺旋遍历的路径
x_path = []
y_path = []
for index, value in enumerate(spiral_result):
    for i in range(len(matrix_example)):
        for j in range(len(matrix_example[0])):
            if matrix_example[i][j] == value:
                x_path.append(j)
                y_path.append(i)

ax.plot(x_path, y_path, marker='o', color='red')

ax.set_xticks([])
ax.set_yticks([])
ax.set_title("Spiral Traversal Visualization")

plt.show()