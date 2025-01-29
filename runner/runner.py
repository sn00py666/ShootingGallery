import pyautogui
import time
import subprocess

pyautogui.FAILSAFE = False

# Чтение путей из файла
with open("paths.txt", "r", encoding="utf-8") as file:
    paths = [line.strip() for line in file.readlines() if line.strip()]

if len(paths) < 2:
    raise ValueError("В файле paths.txt должно быть как минимум два пути к исполняемым файлам.")

shooting_trainer_path = paths[0]  # Первый путь - Shooting Trainer
shooting_gallery_path = paths[1]  # Второй путь - Shooting Gallery

# Запуск программы
subprocess.Popen(shooting_trainer_path)

# Ожидание загрузки
time.sleep(5)

pyautogui.click(x=1860, y=61)
time.sleep(1)
pyautogui.click(x=1860, y=130)
time.sleep(1)

# Нажатие кнопки
pyautogui.click(x=480, y=820)  # Укажите координаты кнопки
time.sleep(15)

# Перемещение окна
pyautogui.moveTo(x=1920, y=1080/2)  # Наведение на заголовок окна
pyautogui.dragTo(x=5, y=1080/2, duration=1)  # Перемещение вниз
time.sleep(3)

pyautogui.click(x=1340, y=880)

# Запуск второй программы
subprocess.Popen(shooting_gallery_path)
