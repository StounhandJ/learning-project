#include <iostream>
#include <windows.h>
#include <string>
#include "src/hero/grade/WarriorClass.h"

void clear(){
    system("cls");
}
int main() {
    SetConsoleCP(CP_UTF8);
    SetConsoleOutputCP(CP_UTF8);
    WarriorClass hero = WarriorClass("Tom");
    hero.addExperience(300);
    std::cout << "Уровень "+std::to_string(hero.getLevel()) << std::endl;
    hero.addExperience(400);
    std::cout << "Уровень "+std::to_string(hero.getLevel()) << std::endl;
    return 0;
}
