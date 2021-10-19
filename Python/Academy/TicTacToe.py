# write your code here
game_not_finished = 'Game not finished'
found_wins = game_not_finished
mover = 'X'

#  печатаем игровую доску
def print_board():
    print('-' * 9)
    for i in range(3):
        print(f'| {matrix[i][0]} {matrix[i][1]} {matrix[i][2]} |') # 1 2 3
    print('-' * 9)

#  Выводим результат | валидируем, | вводим опять
def ask_new_place():
    moved = False
    global mover

    global matrix
    while not moved:
        new_coordinates = input('Enter the coordinates:').split()
        valid_coordinate = True
        for i in new_coordinates:
            if not i.isdigit():
                valid_coordinate = False
                break

        # выяснить место назначения
        x = -1
        y = -1
        if valid_coordinate:
            x = int(new_coordinates[0]) - 1
            y = int(new_coordinates[1]) - 1

        if len(new_coordinates) != 2 or not valid_coordinate:
            print('You should enter numbers!')
        elif not (0 <= x <= 2 and 0 <= y <= 2): # координаты уже переведены в индексы матрицы
            print('Coordinates should be from 1 to 3!')

        elif matrix[x][y] != ' ':
            print('This cell is occupied! Choose another one!')
        else:
            #  координаты прошли валидацию
            # установить новый значок в указанное место
            matrix[x][y] = mover
            moved = True
            # вывести доску на экран
            # провалидировать игру на окончание

    # передаем ход другому игроку
    if mover == 'X':
        mover = 'O'
    else:
        mover = 'X'
    return moved

def count_symbol_in_matrix(symbol):
    counter = 0
    for i in range(3):
        for j in range(3):
            if matrix[i][j] == symbol:
                counter += 1
    return counter

def output_result():
    if found_wins == 'X' or found_wins == 'O':
        print(f'{found_wins} wins')
        return False
    elif found_wins == game_not_finished:
        if ask_new_place():
            return True
    else:
        print(found_wins)
        return False

# Валидируем результаты
def validate_result():

    global found_wins

    # проверка возможности, что разница кол-ва X и O не больше 1
    if not (-1 <= count_symbol_in_matrix('X') - count_symbol_in_matrix('O') <= 1):
        found_wins = 'Impossible'

    if found_wins != 'Impossible':
        # по горизонтали
        for i in range(3):
            if matrix[i][0] == matrix[i][1] == matrix[i][2] != ' ':
                if found_wins != game_not_finished: # найдено второе пересечение, это невозможно
                    found_wins = 'Impossible'
                    break
                else:
                    found_wins = f'{matrix[i][0]}'


    if found_wins != 'Impossible':
        # по вертикали
        for i in range(3):
            if matrix[0][i] == matrix[1][i] == matrix[2][i] != ' ':
                if found_wins != game_not_finished: # найдено второе пересечение, это невозможно
                    found_wins = 'Impossible'
                    break
                else:
                    found_wins = f'{matrix[0][i]}'

    # по диагонали
    if found_wins != 'Impossible' and (matrix[0][0] == matrix[1][1] == matrix[2][2] != ' ' or matrix[2][0] == matrix[1][1] == matrix[0][2] != ' '):
        if found_wins != game_not_finished: # найдено второе пересечение, это невозможно
            found_wins = 'Impossible'
        else:
            found_wins = f'{matrix[1][1]}'

    # случай ничьи
    if found_wins == game_not_finished and count_symbol_in_matrix(' ') == 0:
        found_wins = 'Draw'


## Ну вот тут в нашей простыне появляются наконец то место запуска и выполнения приложения

input_field = ' ' * 9
matrix = [ [0]*3 for i in range(3) ]
n = 0
for i in range(3):
    for j in range(3):
        matrix[i][j] = input_field[n]
        n += 1
# print(matrix)
while found_wins == game_not_finished:
    print_board()
    validate_result()
    output_result()
